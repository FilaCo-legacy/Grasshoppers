using System;
using System.Collections.Generic;
using ImpLite.Bodies;

namespace ImpLite.NarrowPhase
{
    internal class NarrowPhaseManager<T> where T:Collider
    {
        private readonly HashTable<Collider> _hashTable;

        private readonly List<Collider> _colliders;

        private readonly int _iterations;

        private void Initialize()
        {
            foreach (var cur in _colliders)
            {
                cur.Initialize();
            }
        }
        
        private void ApplyImpulse()
        {
            for (var i = 0; i < _iterations; ++i)
            {
                foreach (var cur in _colliders)
                {
                    cur.ApplyImpulse();
                }
            }
        }

        private void PositionalCorrection()
        {
            foreach (var cur in _colliders)
            {
                cur.PositionalCorrection();
            }
        }

        public void Clear()
        {
            _hashTable.Clear();
        }

        public void Add(RigidBody lhsBody, RigidBody rhsBody)
        {
            var collider = new Collider(lhsBody, rhsBody);
            var reverseCollider = new Collider(rhsBody, lhsBody);
            
            if (_hashTable.Contains(collider) || _hashTable.Contains(reverseCollider))
                return;
            
            _colliders.Add(collider);
        }

        public void Execute()
        {
            Initialize();
            ApplyImpulse();
            PositionalCorrection();
        }
    }
}