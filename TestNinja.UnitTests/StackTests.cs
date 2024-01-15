using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Push_NullObject_ThrowArgumentNullException()
        {
            string obj = null;
            Assert.That(() => _stack.Push(obj), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidObject_ObjectAddedToList()
        {
            _stack.Push("a");
            Assert.That(_stack.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void Pop_ListIsEmpty_InvalidOperationException(){}
        
        // POP
        //     Si la lista esta vacia, deberia de lanzar una excepsion 
        //     Si la lista tiene al menos un elemento deberia de devolver el elemento eliminado(debe ser el ultimo)
        
    }
}