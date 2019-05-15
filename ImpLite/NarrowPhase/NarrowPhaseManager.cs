using System;
using System.Collections.Generic;
using ImpLite.Bodies;

namespace ImpLite.NarrowPhase
{
    internal class NarrowPhaseManager<T> where T:Collider, IEquatable<T>
    {
        private readonly HashTable<T> _hashTable;        
        
        public void Clear()
        {
            
        }
    }
}