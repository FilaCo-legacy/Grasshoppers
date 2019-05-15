using ImpLite.BroadPhase;

namespace ImpLite.Bodies
{
    public partial class RigidBody : IMask, IBoxable
    {
        private float _inverseMass;
        
        public Vector2 Position { get; set; }

        public Vector2 Force { get; set; }
        
        public Vector2 Velocity { get; set; }
        
        public Material Material { get; set; }

        public float Mass
        {
            get
            {
                if (_inverseMass < ImpParams.GetInstance.Epsilon)
                    return 0.0f;

                return 1.0f / InverseMass;
            }
        }
        
        public float InverseMass => _inverseMass;

        public bool IsKinematic { get; set; }

        public void SetStatic()
        {
            _inverseMass = 0.0f;
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