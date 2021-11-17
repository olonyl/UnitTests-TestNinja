using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Stack.Mutable
{
    public interface IMutableStack<T>
    {
        T Peek();
        void Push(T element);
        void Pop();
        bool IsEmpty { get; }
    }
}
