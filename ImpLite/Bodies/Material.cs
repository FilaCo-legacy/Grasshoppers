namespace ImpLite.Bodies
{
    public struct Material
    {
        public float Density { get; }
         
        public float Restitution { get; }
        
        public float DynamicFriction { get; }
        
        public float StaticFriction { get; }

        public Material(float density, float restitution, float dynamicFriction, float staticFriction)
        {
            Density = density;
            Restitution = restitution;
            DynamicFriction = dynamicFriction;
            StaticFriction = staticFriction;
        }
    }
}