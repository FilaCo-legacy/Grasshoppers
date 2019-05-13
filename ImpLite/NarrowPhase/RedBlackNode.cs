using System;

namespace ImpLite.NarrowPhase
{
    /// <summary>
    /// Support class that implements a node of a <see cref="RedBlackTree{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    internal class RedBlackNode<TKey, TValue>
    {
        private const int Left = 0;
        private const int Right = 1;

        private readonly RedBlackNode<TKey, TValue>[] _link;

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public bool Red { get; set; }        

        public RedBlackNode<TKey, TValue> this[int dir]
        {
            get
            {
                if (dir != Left && dir != Right)
                    throw new Exception("Incorrect index of the child");
                return _link[dir];
            }
            set
            {
                if (dir != Left && dir != Right)
                    throw new Exception("Incorrect index of the child");
                _link[dir] = value;
            }
        }

        public int Count
        {
            get
            {
                var sum = 1;

                if (this[Left] != null)
                    sum += this[Left].Count;

                if (this[Right] != null)
                    sum += this[Right].Count;

                return sum;
            }
        }

        public RedBlackNode()
        {
            Key = default;
            Value = default;
            Red = true;
            _link = new RedBlackNode<TKey, TValue>[2];
        }

        public RedBlackNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Red = true;
            _link = new RedBlackNode<TKey, TValue>[2];
        }

        public RedBlackNode<TKey, TValue> SingleRotate(int dir)
        {
            if (dir != Left && dir != Right)
                throw new Exception("Incorrect rotate direction");

            var save = this[1 - dir];
            this[1 - dir] = save[dir];
            save[dir] = this;

            Red = true;
            save.Red = false;

            return save;
        }

        public RedBlackNode<TKey, TValue> DoubleRotate(int dir)
        {
            this[1 - dir] = this[1 - dir].SingleRotate(1 - dir);
            return SingleRotate(dir);
        }

        public static void Swap(RedBlackNode<TKey, TValue> nodeA, RedBlackNode<TKey, TValue> nodeB)
        {
            var tmpKey = nodeA.Key;
            nodeA.Key = nodeB.Key;
            nodeB.Key = tmpKey;

            var tmpValue = nodeA.Value;
            nodeA.Value = nodeB.Value;
            nodeB.Value = tmpValue;
        }        

        public static bool IsRed(RedBlackNode<TKey, TValue> node)
        {
            return node != null && node.Red;
        }
    }
}
