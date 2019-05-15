using System.Collections.Generic;
using System.Linq;
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
        
        public MaskFilter Filter { get; set; }

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
            _npManager.Clear();
        }

        private void TransferPhase()
        {
            foreach (var lhsBody in _bodies)
            {
                var candidates = _bpManager.GetCandidates(lhsBody);

                foreach (var rhsBody in candidates)
                {
                    if (Filter.Invoke(lhsBody, rhsBody))
                        _npManager.Add(lhsBody, rhsBody);
                }
            }
        }
        
        public void Step()
        {
            _bpManager.Initialize(_bodies);

            TransferPhase();
            
            
        }
        
    }
}