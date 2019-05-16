using System;
using System.Collections.Generic;
using ImpLite.Bodies;

namespace ImpLite.NarrowPhase
{
    internal class NarrowPhaseManager<T> where T:Collider
    {
        private readonly HashTable<Collider> _hashTable;

        private readonly List<Collider> _contacts;

        public NarrowPhaseManager()
        {
            _hashTable = new HashTable<Collider>();
            _contacts = new List<Collider>();
        }

        private void Initialize()
        {
            foreach (var cur in _contacts)
            {
                cur.Initialize();
            }
        }
        
        private void ApplyImpulse()
        {
            for (var i = 0; i < ImpParams.GetInstance.SceneIterations; ++i)
            {
                foreach (var cur in _contacts)
                {
                    cur.ApplyImpulse();
                }
            }
        }

        public void PositionalCorrection()
        {
            foreach (var cur in _contacts)
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
            
            _contacts.Add(collider);
        }

        public void Execute()
        {
            Initialize();
            ApplyImpulse();
        }
    }
}