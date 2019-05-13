namespace ImpLite.BroadPhase
{
    /// <summary>
    /// Interface that defines the type of the object and rules of collisions
    /// </summary>
    public interface IMask
    {
        /// <summary>
        /// Defines categories of objects that might collide with this object
        /// </summary>
        ushort MaskBits { get; set; }

        /// <summary>
        /// Defines the group of current object
        /// </summary>
        ushort CategoryBits { get; set; }
        
    }
}
