using System;
using System.Collections.Generic;

namespace Gestor.Models
{
    public class Stack<T>
    {
        private readonly List<T> _stack;

        public Stack()
        {
            _stack = new List<T>();
        }

        public void Push(T obj)
        {
            _stack.Add(obj);
        }

        public object Pop()
        {
            var depth = _stack.Count;
            var popped = _stack[depth - 1];
            _stack.RemoveAt(depth - 1);
            return popped;
        }

        public void Clear()
        {
            _stack.Clear();
        }

        public int Depth()
        {
            return _stack.Count;
        }
    }
}