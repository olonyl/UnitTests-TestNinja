using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    class StackTests
    {
        [Test]
        public void Push_NullObject_ReturnArgumentNullException()
        {
            var stack = new Stack<string>();

            Assert.Throws<ArgumentNullException>(() => stack.Push(null));
        }
        [Test]
        public void Push_OneObject_ReturnCounterEqualOne()
        {
            var stack = new Stack<string>();

            stack.Push("hello");

            Assert.That(1, Is.EqualTo(stack.Count));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();

            Assert.That(0, Is.EqualTo(stack.Count));
        }


        [Test]
        public void Pop_EmptyStack_ReturnInvalidOperationException()
        {
            var stack = new Stack<string>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Pop_StackWithFewObjects_ReturnObjectOnTheTop()
        {
            var stack = new Stack<string>();

            stack.Push("hello");
            stack.Push("world");
            stack.Push("again");

            var result = stack.Pop();

            Assert.That(result, Is.EqualTo("again"));
        }


        [Test]
        public void Pop_StackWithFewObjects_RemoveObjectOnTheTop()
        {
            var stack = new Stack<string>();

            stack.Push("hello");
            stack.Push("world");
            stack.Push("again");

            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ReturnInvalidOperationException()
        {
            var stack = new Stack<string>();

            Assert.Throws<InvalidOperationException>(()=> stack.Peek());
        }

        [Test]
        public void Peek_StackWithObjects_ReturnObjectOnTopOfTheStack()
        {
            var stack = new Stack<string>();

            stack.Push("hello");
            stack.Push("world");
            stack.Push("again");

            var result = stack.Peek();

            Assert.That("again", Is.EqualTo(result));
        }

        [Test]
        public void Peek_StackWithObjects_ReturnDoesNotRemoveTheObjectOnTopOfTheStack()
        {
            var stack = new Stack<string>();

            stack.Push("hello");
            stack.Push("world");
            stack.Push("again");

            stack.Peek();

            Assert.That(3, Is.EqualTo(stack.Count));
        }


    }
}
