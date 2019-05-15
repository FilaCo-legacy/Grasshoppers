using System;
using ImpLite.Bodies;
using ImpLite.NarrowPhase.Solvers;

namespace ImpLite.NarrowPhase
{
    internal class Collider : IEquatable<Collider>
    {
        private float _mixedRestitution;
        private float _mixedStaticFriction;
        private float _mixedDynamicFriction;
        
        public RigidBody BodyA { get; }
        
        public RigidBody BodyB { get; }
        
        public ISolver Solver { get; }
        
        public float Penetration { get; set; }
        
        public Vector2 Normal { get; set; }

        public Collider(RigidBody bodyA, RigidBody bodyB)
        {
            BodyA = bodyA;
            BodyB = bodyB;
        }

        public void ResolveCollision()
        {
            Solver.Solve(this);
        }

        public void PositionalCorrection()
        {
            var Percentage = ImpParams.GetInstance.PercentLinearProjection;
            var Slop = ImpParams.GetInstance.Slop;
            
            var correction = Math.Max(Penetration - Slop, 0.0f) / 
                                  (BodyA.InverseMass + BodyB.InverseMass) * Percentage * Normal;
            BodyA.Position -= BodyA.InverseMass * correction;
            BodyB.Position += BodyB.InverseMass * correction;
        }

        public void Initialize()
        {
            _mixedRestitution = Math.Min(BodyA.Material.Restitution, BodyB.Material.Restitution);

            _mixedStaticFriction = (float)Math.Sqrt(BodyA.Material.StaticFriction * BodyB.Material.StaticFriction);
            _mixedDynamicFriction = (float)Math.Sqrt(BodyA.Material.DynamicFriction * BodyB.Material.DynamicFriction);
            
            
        }

        public bool Equals(Collider other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(BodyA, other.BodyA) && Equals(BodyB, other.BodyB);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Collider) obj);
        }

        public override int GetHashCode()
        {
            var bodyAHash = BodyA.GetHashCode();
            var bodyBHash = BodyB.GetHashCode();

            var str = string.Format(bodyAHash.ToString() + bodyBHash.ToString());
            
            const int p = 31;

            var hash = 0;
            var pPow = 1;

            for (var i = 0; i < str.Length; ++i)
            {
                hash += (str[i] - '0' + 1) * pPow;

                pPow *= p;
            }

            return hash;
        }
    }
}