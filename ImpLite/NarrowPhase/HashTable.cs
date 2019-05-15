using System;

namespace ImpLite.NarrowPhase
{
    internal class HashTable <T> where T : IEquatable<T>
    {
        private readonly HashEntry<T>[] _table;

        public const int MaxTableSize = (int) 5e6 + 11;

        public HashTable(int size = MaxTableSize)
        {
            _table = new HashEntry<T>[size];

            Clear();
        }

        private int GetHashCode(T value)
        {
            return value.GetHashCode() % _table.Length;
        }
        
        public void Add(T value)
        {
            var hash = GetHashCode(value);
            
            if (_table[hash] == null)
                _table[hash] = new HashEntry<T>(value);
            else if (!_table[hash].Contains(value))
                _table[hash].Add(value);
        }

        public bool Contains(T value)
        {
            var hash = GetHashCode(value);

            return _table != null && _table[hash].Contains(value);
        }

        public void Clear()
        {
            for (var i = 0; i < _table.Length; ++i)
                _table[i] = null;   
        }
    }
}