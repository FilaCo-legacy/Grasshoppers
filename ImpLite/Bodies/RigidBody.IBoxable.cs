using ImpLite.BroadPhase;

namespace ImpLite.Bodies
{
    public partial class RigidBody
    {
        public Box GetBox
        {
            get
            {
                var localBox = Shape.GetBox();
                
                localBox.LeftUpper.Set(Position.X/2.0f, Position.Y/2.0f);

                return localBox;
            }
        }
        
    }
}