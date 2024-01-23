using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class HousekeeperHelperTests
    {
        private Mock<IEmailSender> _sender;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IUnitOfWork> _repo;
        private DateTime _statementDate = new DateTime(2001, 06, 28);
        private Housekeeper _houseKeeper;
        private string _statementFileName = "filename";

        [SetUp]
        public void SetUp()
        {
            _houseKeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };
            
            _sender = new Mock<IEmailSender>();
            
            _statementGenerator = new Mock<IStatementGenerator>();
            
            _repo = new Mock<IUnitOfWork>();
            _repo.Setup(unit => unit.Query<Housekeeper>()).Returns(
                new List<Housekeeper>
                { _houseKeeper }.AsQueryable());
        }
        
        [Test]
        public void SendStatementEmails_EmailsSendSuccessfully_ReturnTrue()
        {
            var result = HousekeeperHelper.SendStatementEmails(_statementDate, _repo.Object, _statementGenerator.Object, _sender.Object);
            
            Assert.That(result, Is.True);
        }

        [Test]

        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            HousekeeperHelper.SendStatementEmails(_statementDate, _repo.Object, _statementGenerator.Object, _sender.Object);
            
            _statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate));
        }

        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsNull_ShouldNotGenerateStatements()
        {
            _houseKeeper.Email = null;
            
            HousekeeperHelper.SendStatementEmails(_statementDate, _repo.Object, _statementGenerator.Object, _sender.Object);
            
            _statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate), Times.Never);
        }
        
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsWhiteSpace_ShouldNotGenerateStatements()
        {
            _houseKeeper.Email = " ";
            
            HousekeeperHelper.SendStatementEmails(_statementDate, _repo.Object, _statementGenerator.Object, _sender.Object);
            
            _statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate), Times.Never);
        }
        
        [Test]
        public void SendStatementEmails_WhenCalled_SendEmails()
        {
            _statementGenerator.Setup(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
                .Returns(_statementFileName);
            
            HousekeeperHelper.SendStatementEmails(_statementDate, _repo.Object, _statementGenerator.Object, _sender.Object);

            _sender.Verify(sender => sender.EmailFile(
                _houseKeeper.Email, 
                _houseKeeper.StatementEmailBody, 
                _statementFileName, 
                It.IsAny<string>()));
        }

        [Test]
        public void SendStatementEmails_StatementFilenameIsEmpty_ShouldNotSendEmails()
        {
            _statementGenerator.Setup(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
                .Returns("");
            
            HousekeeperHelper.SendStatementEmails(_statementDate, _repo.Object, _statementGenerator.Object, _sender.Object);

            _sender.Verify(sender => sender.EmailFile(
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>()), Times.Never);   
        }
        
        [Test]
        public void SendStatementEmails_CouldNotSendEmail_ThrowException()
        {
            _statementGenerator.Setup(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, _statementDate))
                .Returns("");
            
            HousekeeperHelper.SendStatementEmails(_statementDate, _repo.Object, _statementGenerator.Object, _sender.Object);

            _sender.Verify(sender => sender.EmailFile(
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>()), Times.Never);   
        }
        
        
    }
}