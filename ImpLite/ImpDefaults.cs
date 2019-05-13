namespace ImpLite
{
    public class ImpDefaults
    {
        private static readonly ImpDefaults _instance = new ImpDefaults();

        public static ImpDefaults GetInstance => _instance;

        protected ImpDefaults()
        {
            TimeStep = 1.0f / 60.0f;
            Gravity = new Vector2(0, 9.8f);
            Epsilon = 1e-7f;
        }

        public float TimeStep { get; set; }
        
        public Vector2 Gravity { get; set; }
        
        public float Epsilon { get; set; }
    }
}