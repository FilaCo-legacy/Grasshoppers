using ImpLite.Bodies;
using ImpLite.NarrowPhase.Solvers;

namespace ImpLite.NarrowPhase
{
    internal class Collider
    {
        public RigidBody BodyA { get; }
        
        public RigidBody BodyB { get; }
        
        public ISolver Solver { get; }
        
        public float Penetration { get; set; }
        
        public Vector2 Normal { get; set; }
    }
}