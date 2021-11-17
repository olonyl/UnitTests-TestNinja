using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Stack.Immutable;

namespace TestNinja.UnitTests.Stack.Immutable
{
    class ImmutableStackTests
    {
        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            var emptyStack = MyImmutableStack<int>.Empty;

            Assert.IsTrue(emptyStack.IsEmpty);
        }

        [Test]
        public void Peek_EmptyStack_ThrowsException()
        {
            var emptyStack = MyImmutableStack<int>.Empty;

            Assert.Throws<InvalidOperationException>(() => emptyStack.Peek());
            Assert.Throws<InvalidOperationException>(() => emptyStack.Pop());
        }

        [Test]
        public void PushOnEmptyStackTwoItems_PeekOneElement_ReturnsCorrectValue()
        {
            var stack = MyImmutableStack<int>.Empty;
            stack = stack.Push(1);
            stack = stack.Push(2);

            int result = stack.Peek();
            Assert.AreEqual(result, 2);
        }

        [Test]
        public void PushOnEmptyStackOneElement_PopOneElement_ReturnsEmptyStack()
        {
            var stack = MyImmutableStack<int>.Empty;
            stack = stack.Push(1);
            var result = stack.Pop();

            Assert.IsTrue(result.IsEmpty);
        }
    }
}
