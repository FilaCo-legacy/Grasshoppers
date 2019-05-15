using ImpLite.BroadPhase;

namespace ImpLite.Shapes
{
    public struct BoxShape : IShape
    {
        private readonly Box _box;

        public float Width => _box.Width;

        public float Height => _box.Height;

        public ShapeType Type => ShapeType.Box;

        public BoxShape(float width, float height)
        {
            _box = new Box(0.0f, 0.0f, width, height);
        }

        public float CalculateArea()
        {
            return _box.Width * _box.Height;
        }

        public Box GetBox()
        {
            return _box;
        }

        public float ComputeMass(float density)
        {
            return density * CalculateArea();
        }

        public float ComputeInertia(float mass)
        {
            return 0.0f;
        }

        public object Clone()
        {
            var clone = new BoxShape(_box.Width, _box.Height);
            return clone;
        }
    }
}