using ImpLite.BroadPhase;

namespace ImpLite.Bodies
{
    public partial class RigidBody : IMask, IBoxable
    {
        public Vector2 Position { get; set; }

        public Vector2 Force { get; set; }
        
        public Vector2 Velocity { get; set; }
        
        public Material Material { get; set; }

        public float Mass
        {
            get
            {
                if (InverseMass < ImpParams.GetInstance.Epsilon)
                    return 0.0f;

                return 1.0f / InverseMass;
            }
        }
        
        public float InverseMass { get; private set; }

        public bool IsKinematic { get; set; }

        public void SetStatic()
        {
            InverseMass = 0.0f;
        }

        public void ApplyForceToCenter(Vector2 force)
        {
            Force += force;
        }
        
        public void ApplyImpulseToCenter(Vector2 impulse)
        {
            Velocity += InverseMass * impulse;
        }
    }
}