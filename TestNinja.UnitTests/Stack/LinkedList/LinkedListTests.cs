using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Stack.LinkedList;

namespace TestNinja.UnitTests.Stack.LinkedList
{
    class LinkedListTests
    {
        [Test]
        public void CreateNode_SetsValueAndNextIsNull()
        {
            ListNode<int> node = new ListNode<int>(1);

            Assert.AreEqual(node.Value, 1);
            Assert.IsNull(node.Next);
        }

        [Test]
        public void AddFirst_HeadAndTailAreSame()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddFirst(1);

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Tail.Value, 1);
            Assert.AreSame(list.Head, list.Tail);
        }

        [Test]
        public void AddFirstTwoElements_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);

            Assert.AreEqual(list.Tail.Value, 1);
            Assert.AreEqual(list.Head.Value, 2);
            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list.Head.Next, list.Tail);

        }

        [Test]
        public void AddLast_HeadAndTailAreSame()
        {
            var list = new MyLinkedList<int>();
            list.AddLast(1);

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Tail.Value, 1);
            Assert.AreSame(list.Head, list.Tail);

        }

        [Test]
        public void AddLastTwoElements_ListIsIncorrectState()
        {
            var list = new MyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Tail.Value, 2);
            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list.Head.Next, list.Tail);
        }

        [Test]
        public void RemoveFirst_EmptyList_Throws()
        {
            var list = new MyLinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Test]
        public void RemoveLast_OneElement_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddFirst(1);

            list.RemoveLast();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(list.Count, 0);
        }

        [Test]
        public void RemoveLast_TowElements_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.RemoveLast();

            Assert.AreEqual(list.Head.Value, 1);
            Assert.AreEqual(list.Count , 1);
            Assert.AreSame(list.Head, list.Tail);
        }

        [Test]
        public void RemoveFirst_OneElement_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddFirst(1);

            list.RemoveFirst();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(list.Count, 0);
        }

        [Test]
        public void RemoveLast_EmptyList_Throws()
        {
            var list = new MyLinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }       
    }

}
