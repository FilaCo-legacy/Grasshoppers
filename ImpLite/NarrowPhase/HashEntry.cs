using System;

namespace ImpLite.NarrowPhase
{
    internal class HashEntry <T> where  T:IEquatable<T>
    {
        private HashEntry<T> _next;
        private T Value { get; set; }

        public HashEntry(T value)
        {
            Value = value;
            _next = null;
        }

        public void Add(T value)
        {
            var cur = this;

            while (cur._next != null)
                cur = cur._next;
            
            cur._next = new HashEntry<T>(value);
        }

        public bool Contains(T value)
        {
            var cur = this;

            while (cur != null && !cur.Value.Equals(value))
                cur = cur._next;

            if (cur == null)
                return false;

            return true;
        }
    }
}