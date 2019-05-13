namespace ImpLite
{
    public class ImpParams
    {
        private static readonly ImpParams _instance = new ImpParams();

        public static ImpParams GetInstance => _instance;

        protected ImpParams()
        {
            TimeStep = 1.0f / 60.0f;
            Gravity = new Vector2(0, 9.8f);
            Epsilon = 1e-7f;
            GravityScale = 5.0f;
        }

        public float TimeStep { get; set; }
        
        public Vector2 Gravity { get; set; }
        
        public float Epsilon { get; set; }
        
        public float GravityScale { get; set; }
    }
}