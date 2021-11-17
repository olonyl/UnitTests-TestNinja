using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Stack.LinkedList
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public ListNode<T> Next { get; set; }
    }
}
