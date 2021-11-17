using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Stack.Immutable
{
    public interface IImmutableStack<T>
    {
        T Peek();
        IImmutableStack<T> Pop();
        IImmutableStack<T> Push(T element);
        bool IsEmpty { get; }
    }
}
