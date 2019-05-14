namespace ImpLite.NarrowPhase.Solvers
{
    /// <summary>
    /// Interface that defines classes that solve the collision between two rigid bodies
    /// </summary>
    internal interface ISolver
    {
        /// <summary>
        /// Solve the collision between two rigid bodies in the collider
        /// </summary>
        /// <param name="collider"></param>
        void Solve(Collider collider);
    }
}