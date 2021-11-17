using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Stack.Mutable;

namespace TestNinja.UnitTests.Stack.Mutable
{
    class MutableStackTests
    {
        [Test]
        public void IsEmtpy_EmptyStack_ReturnsTrue()
        {
            var stack = new MyMutableStack<int>();

            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            var stack = new MyMutableStack<int>();
            stack.Push(1);

            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            var stack = new MyMutableStack<int>();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadItem()
        {
            var stack = new MyMutableStack<int>();

            stack.Push(1);
            stack.Push(2);

            Assert.That(2, Is.EqualTo(stack.Peek()));
        }

        [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadElement()
        {
            var stack = new MyMutableStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.That(stack.Peek(), Is.EqualTo(1));

        }
    }
}
