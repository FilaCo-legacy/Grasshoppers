using System;
using ImpLite.Bodies;
using ImpLite.Shapes;

namespace ImpLite.NarrowPhase.Solvers
{
    /// <summary>
    /// An implementation of method that solves collision between two AABBs
    /// </summary>
    internal class SolverBoxvsBox:ISolver
    {
        private RigidBody _bodyA;
        private RigidBody _bodyB;
        
        private Vector2 _normal;
        
        private BoxShape _boxA;
        private BoxShape _boxB;
        
        private void Initialize(Collider collider)
        {
            _bodyA = collider.BodyA;
            _bodyB = collider.BodyB;

            _normal = _bodyB.Position - _bodyA.Position;

            _boxA = (BoxShape)_bodyA.Shape;
            _boxB = (BoxShape)_bodyB.Shape;
        }

        private float ComputeOverlapX()
        {
            var halfWidthA = _boxA.Width / 2.0f;
            var halfWidthB = _boxB.Width / 2.0f;

            return halfWidthA + halfWidthB - Math.Abs(_normal.X);
        }
        
        private float ComputeOverlapY()
        {
            var halfHeightA = _boxA.Height / 2.0f;
            var halfHeightB = _boxB.Height / 2.0f;

            return halfHeightA + halfHeightB - Math.Abs(_normal.Y);
        }
        
        public void Solve(Collider collider)
        {
            Initialize(collider);

            var xOverlap = ComputeOverlapX();
            var yOverlap = ComputeOverlapY();

            if (xOverlap > 0 && yOverlap > 0)
            {
                if (xOverlap < yOverlap)
                {
                    if (_normal.X < 0)
                        collider.Normal = new Vector2(-1.0f, 0.0f);
                    else
                        collider.Normal = new Vector2(1.0f, 0.0f);
                }
                else
                {
                    if (_normal.Y < 0)
                        collider.Normal = new Vector2(0.0f, -1.0f);
                    else
                        collider.Normal = new Vector2(0.0f, 1.0f);
                }

                collider.Penetration = Math.Min(xOverlap, yOverlap);
            }
        }
    }
}