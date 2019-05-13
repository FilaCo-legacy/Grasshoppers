using System;
using System.Collections.Generic;

namespace ImpLite.NarrowPhase
{
    internal class RedBlackTree<TKey, TValue>
    {
        private const int Left = 0;
        private const int Right = 1;

        private readonly IComparer<TKey> _comparer;

        private RedBlackNode<TKey, TValue> _root;

        public bool Empty => _root == null;

        public int Count
        {
            get
            {
                if (_root == null)
                    return 0;

                return _root.Count;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                var node = FindNode(key);

                if (node == null)
                    throw new Exception("Element with this key wasn't found");

                return node.Value;
            }
            set
            {
                var node = FindNode(key);

                if (node == null)
                    Insert(key, value);
                else
                    node.Value = value;
            }
        }

        private RedBlackNode<TKey, TValue> FindNode (TKey key)
        {
            var cur = _root;

            while (cur != null)
            {
                switch (_comparer.Compare(key, cur.Key))
                {
                    case 0:
                        return cur;
                    case -1:
                        cur = cur[Left];
                        break;
                    case 1:
                        cur = cur[Right];
                        break;
                }
            }

            return null;
        }

        public RedBlackTree()
        {
            _root = null;
            _comparer = Comparer<TKey>.Default;
        }

        public RedBlackTree(IComparer<TKey> comparer)
        {
            _root = null;
            _comparer = comparer;
        }
             
        public void Insert(TKey key, TValue value)
        {
            // If tree is empty
            if (Empty)
                _root = new RedBlackNode<TKey, TValue>(key, value);
            else
            {
                var head = new RedBlackNode<TKey, TValue>();

                var tmpHead = head;
                RedBlackNode<TKey, TValue> grandParent = null;
                RedBlackNode<TKey, TValue> parent = null;

                head[Right] = _root;
                var cur = head[Right];                

                var dir = Left;
                var last = dir;

                // Go down the tree
                while (true)
                {
                    if (cur == null)
                    {
                        // Add a node as a leaf
                        cur = new RedBlackNode<TKey, TValue>(key, value);
                        parent[dir] = cur;
                    }
                    else if (RedBlackNode<TKey, TValue>.IsRed(cur[Left]) && RedBlackNode<TKey, TValue>.IsRed(cur[Right]))
                    {
                        // Color swapping
                        cur.Red = true;
                        cur[Left].Red = false;
                        cur[Right].Red = false;
                    }

                    // Remove "red violation"
                    if (RedBlackNode<TKey, TValue>.IsRed(cur) && RedBlackNode<TKey, TValue>.IsRed(parent))
                    {
                        var sndDir = tmpHead[Right] == grandParent ? 1 : 0;

                        if (cur == parent[last])
                            tmpHead[sndDir] = grandParent.SingleRotate(1 - last);
                        else
                            tmpHead[sndDir] = grandParent.DoubleRotate(1 - last);

                    }

                    if (_comparer.Compare(cur.Key, key) == 0)
                        break;

                    last = dir;
                    dir = _comparer.Compare(key, cur.Key) == -1 ? 0 : 1;

                    if (grandParent != null)
                        tmpHead = grandParent;
                    grandParent = parent;
                    parent = cur;
                    cur = cur[dir];
                }

                _root = head[Right];
            }

            _root.Red = false;
        }

        public void Erase(TKey key)
        {
            if (!Empty)
            {
                var head = new RedBlackNode<TKey, TValue>();

                RedBlackNode<TKey, TValue> grandParent = null;
                RedBlackNode<TKey, TValue> foundNode = null;
                RedBlackNode<TKey, TValue> parent = null;

                var cur = head;
                cur[Right] = _root;

                var dir = Right;

                // Move down the tree and find red nodes
                while (cur[dir] != null)
                {
                    var last = dir;

                    // Update the refs
                    grandParent = parent;
                    parent = cur;
                    cur = cur[dir];
                    dir = _comparer.Compare(key, cur.Key) == -1 ? 0 : 1;

                    // Save found node
                    if (_comparer.Compare(key, cur.Key) == 0)
                        foundNode = cur;

                    // Push down red nodes
                    if (!RedBlackNode<TKey, TValue>.IsRed(cur) && !RedBlackNode<TKey, TValue>.IsRed(cur[dir]))
                    { 
                        if (RedBlackNode<TKey, TValue>.IsRed(cur[1 - dir]))
                        {
                            parent[last] = cur.SingleRotate(dir);
                            parent = parent[last];
                        }
                        else
                        {
                            var save = parent[1 - last];

                            if (save != null)
                            {
                                if (!RedBlackNode<TKey, TValue>.IsRed(save[1-last]) && !RedBlackNode<TKey, TValue>.IsRed(save[last]))
                                {
                                    // Colour swapping
                                    parent.Red = false;
                                    save.Red = true;
                                    cur.Red = true;
                                }
                                else
                                {
                                    var sndDir = grandParent[Right] == parent ? 1 : 0;

                                    if (RedBlackNode<TKey, TValue>.IsRed(save[last]))
                                        grandParent[sndDir] = parent.DoubleRotate(last);
                                    else if (RedBlackNode<TKey, TValue>.IsRed(save[1 - last]))
                                        grandParent[sndDir] = parent.SingleRotate(last);

                                    // Paint the nodes in correct colours
                                    cur.Red = true;
                                    grandParent[sndDir].Red = true;

                                    grandParent[sndDir][Left].Red = false;
                                    grandParent[sndDir][Right].Red = false;
                                }
                            }
                        }
                    }
                }
                // Swap and remove if we've found the node
                if (foundNode != null)
                {
                    RedBlackNode<TKey, TValue>.Swap(foundNode, cur);

                    parent[cur == parent[Right] ? 1 : 0] = cur[cur[Left] == null ? 1 : 0];
                }

                _root = head[Right];

                if (!Empty)
                    _root.Red = false;
            }
        }

        public bool Contains(TKey key)
        {
            return FindNode(key) != null;
        }        
    }
}
