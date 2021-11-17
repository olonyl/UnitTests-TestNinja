using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Stack.Mutable
{
    public class MyMutableStack<T> : IMutableStack<T>
    {
        public bool IsEmpty => Count == 0;
        private List<T> _elements;
        public int Count => _elements.Count;

        public MyMutableStack()
        {
            _elements = new List<T>();
        }
        public T Peek()
        {
            if(IsEmpty)
                throw new InvalidOperationException();
            return _elements[Count - 1];
        }

        public void Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            _elements.RemoveAt(Count - 1);
            
        }

        public void Push(T element)
        {
            _elements.Add(element);
        }
    }
}
