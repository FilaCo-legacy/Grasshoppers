using System.Collections.Generic;
using ImpLite.Bodies;
using ImpLite.BroadPhase;
using ImpLite.NarrowPhase;

namespace ImpLite
{
    public class World
    {
        private readonly List<RigidBody> _bodies;
        private readonly BroadPhaseManager<RigidBody> _bpManager;
        private readonly NarrowPhaseManager<Collider> _npManager;
        
        public float TimeStep { get; set; }
        
        public Vector2 Gravity { get; set; }
        
        public int Iterations { get; set; }

        private void IntegrateForces(RigidBody body)
        {
            if (body.IsKinematic || body.InverseMass < ImpParams.GetInstance.Epsilon)
                return;
            
            body.LinearVelocity += (body.Force * body.InverseMass + Gravity) * (TimeStep / 2.0f);
        }

        private void IntegrateVelocities(RigidBody body)
        {
            if (body.InverseMass < ImpParams.GetInstance.Epsilon)
                return;
            
            IntegrateForces(body);

            body.Position = body.LinearVelocity * TimeStep;
            
            IntegrateForces(body);
        }

        private void Clear()
        {
            _bpManager.Clear();
        }

        public void Step()
        {
            _bpManager.Initialize(_bodies);

            
        }
        
    }
}