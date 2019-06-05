﻿using System.Collections.Generic;

namespace ImpLite.BroadPhase
{
    /// <summary>
    /// Fast-checker to find objects that can collide during current step.
    /// Physics objects are instantiated as their boxes, which covers their shapes.
    /// </summary>
    internal class BroadPhaseManager <T> where T: IBoxable
    {
        private readonly IBoxTree<T> _boxTree;

        /// <summary>
        /// Initialize an object of <see cref="BroadPhaseManager{T}"/> with given dimensions
        /// </summary>
        /// <param name="sceneWidth">Width of the scene, which this manager is connected with</param>
        /// <param name="sceneHeight">Height of the scene, which this manager is connected with</param>
        internal BroadPhaseManager(int sceneWidth, int sceneHeight)
        {
            _boxTree = new QuadTree<T>(0, new Box(0, 0, sceneWidth, sceneHeight));
        }

        private static void FilterIntersectBoxes(T physObject, List<T> candidates)
        {
            var tmp = new List<T>();

            foreach (var curObject in candidates)
            {
                if (physObject.GetBox.Intersects(curObject.GetBox))
                    tmp.Add(curObject);
            }
            
            candidates.Clear();
            candidates.AddRange(tmp);
        }

        /// <summary>
        /// Adds objects-actors of current step
        /// </summary>
        /// <param name="objects"></param>
        public void Execute(IEnumerable<T> objects)
        {
            foreach (var curObject in objects)
                _boxTree.Insert(curObject);
        }

        /// <summary>
        /// Returns objects that might be collided with given 
        /// </summary>
        /// <param name="physObject"></param>
        /// <returns></returns>
        public List<T> GetCandidates(T physObject)
        {
            var candidates = new List<T>();

            _boxTree.Retrieve(candidates, physObject);
            FilterIntersectBoxes(physObject, candidates);

            return candidates;
        }

        /// <summary>
        /// Clears the list of the objects
        /// </summary>
        public void Clear()
        {
            _boxTree.Clear();
        }
    }
}
