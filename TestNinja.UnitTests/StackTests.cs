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
        public void Count_EmptyStack_ReturnsZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Push_NullObject_ThrowArgumentNullException()
        {
            string obj = null;
            Assert.That(() => _stack.Push(obj), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ValidObject_ObjectAddedToStack()
        {
            _stack.Push("a");
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_StackIsEmpty_InvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }
        
        [Test]
        public void Pop_StackHaveMultipleElements_ReturnTheElementOnTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            _stack.Push("d");
            
            var result = _stack.Pop();
            
            Assert.That(result, Is.EqualTo("d"));
        }
        
        [Test]
        public void Pop_StackHaveMultipleElements_RemoveTheElementOnTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            _stack.Push("d");
            
            _stack.Pop();
            
            Assert.That(_stack.Count, Is.EqualTo(3));
        }

        [Test]
        public void Peek_StackIsEmpty_InvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }
        
        [Test]
        public void Peek_StackHaveMultipleElements_ReturnTheElementOnTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            _stack.Push("d");
            
            var result = _stack.Peek();
            
            Assert.That(result, Is.EqualTo("d"));
        }
        
        [Test]
        public void Peek_StackHaveMultipleElements_ShouldNotRemoveTheElementOnTop()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");
            _stack.Push("d");
            
            var result = _stack.Peek();
            
            Assert.That(_stack.Count, Is.EqualTo(4));
        }
        
    }
}