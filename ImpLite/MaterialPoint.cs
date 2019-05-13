using System.Numerics;

namespace ImpLite
{
    internal abstract class MaterialPoint
    {
        private float _inverseMass;
        
        public Vector2 Position { get; set; }
        
        public Vector2 Force { get; set; }
        
        public Vector2 Velocity { get; set; }

        public float Mass
        {
            get
            {
                if (_inverseMass < ImpParams.GetInstance.Epsilon)
                    return 0.0f;

                return 1.0f / _inverseMass;
            }
            set
            {
                if (value < ImpParams.GetInstance.Epsilon)
                    _inverseMass = 0.0f;

                _inverseMass = 1.0f / value;
            }
        }

        public float InverseMass => _inverseMass;
        
        public float GravityScale { get; set; }

        public MaterialPoint(Vector2 position, float mass)
        {
            Position = position;
            Mass = mass;
            GravityScale = ImpParams.GetInstance.GravityScale;
            Velocity = new Vector2(0.0f,0.0f);
            Force = new Vector2(0.0f, 0.0f);
        }

        public void ApplyForce(Vector2 force)
        {
            Force += force;
        }
        
    }
}