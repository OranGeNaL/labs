using System;
using System.Collections.Generic;
using System.Text;

namespace Prog
{
    class ListNode<T>
    {
        ListContainer<T> container;

        public ListNode<T> prev;
        public ListNode<T> next;

        public T Value { get; set; }

        public ListNode(T _value, ListContainer<T> _container)
        {
            Value = _value;
            container = _container;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
