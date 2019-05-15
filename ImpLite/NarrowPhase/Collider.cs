using System;
using ImpLite.Bodies;
using ImpLite.NarrowPhase.Solvers;

namespace ImpLite.NarrowPhase
{
    internal class Collider
    {
        private float _mixedRestitution;
        private float _mixedStaticFriction;
        private float _mixedDynamicFriction;
        
        public RigidBody BodyA { get; }
        
        public RigidBody BodyB { get; }
        
        public ISolver Solver { get; }
        
        public float Penetration { get; set; }
        
        public Vector2 Normal { get; set; }

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
    }
}