using System;

namespace ImpLite.NarrowPhase
{
    internal class HashTable <T> where T : IEquatable<T>
    {
        private readonly HashEntry<T>[] _table;

        private const int TableSize = (int) 5e6 + 11;

        public HashTable()
        {
            _table = new HashEntry<T>[TableSize];

            Clear();
        }

        private static int GetHashCode(T value)
        {
            return value.GetHashCode() % TableSize;
        }
        
        public void Add(T value)
        {
            var hash = GetHashCode(value);
            
            if (_table[hash] != null &&_table[hash].Contains(value))
                _table[hash].Add(value);
        }

        public bool Contains(T value)
        {
            var hash = GetHashCode(value);

            return _table != null && _table[hash].Contains(value);
        }

        public void Clear()
        {
            for (var i = 0; i < TableSize; ++i)
                _table[i] = null;   
        }
    }
}