using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Stack.Immutable
{
    public class MyImmutableStack<T> : IImmutableStack<T>
    {
        internal class EmptyStack : IImmutableStack<T>
        {
            public bool IsEmpty => true;

            public T Peek()
            {
                throw new InvalidOperationException();
            }

            public IImmutableStack<T> Pop()
            {
                throw new InvalidOperationException();
            }

            public IImmutableStack<T> Push(T element)
            {
                return new MyImmutableStack<T>(element, this);
            }
        }

        private static readonly EmptyStack _empty = new EmptyStack();
        public bool IsEmpty => throw new NotImplementedException();
        private T _head;
        private IImmutableStack<T> _tail;
        public static IImmutableStack<T> Empty => _empty;

        public MyImmutableStack(T head, IImmutableStack<T> tail)
        {
            _head = head;
            _tail = tail;
        }

        public T Peek()
        {
            return _head;
        }

        public IImmutableStack<T> Pop()
        {
            return _tail;
        }

        public IImmutableStack<T> Push(T element)
        {
            return new MyImmutableStack<T>(element, this);
        }
    }

   
}
