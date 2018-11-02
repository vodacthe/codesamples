using System;

namespace BinarySearchTree
{
    public static class Tree
    {
        #region Create Tree & Insert Nodes
        public static void CreateTree(ref Node root, string input)
        {
            root = null;
            string[] datas = input.Split(' ');
            foreach (string data in datas)
            {
                if (!string.IsNullOrEmpty(data))
                {
                    root = InsertNode(root, int.Parse(data));
                }
            }
        }
        public static Node InsertNode(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else if (value >= root.value)
            {
                root.pRight = InsertNode(root.pRight, value);
            }
            else
            {
                root.pLeft = InsertNode(root.pLeft, value);
            }
            return root;
        }
        #endregion

        #region Search/Edit/Remove Nodes
        public static Node SearchNode(Node node, int val)
        {
            if (node == null)
            {
                return null;
            }
            else
            {
                if (val < node.value) //If value is < current node value => search for that value on the left
                {
                    return SearchNode(node.pLeft, val);
                }
                else if (val > node.value) //If value is > current node value => search for that value on the right
                {
                    return SearchNode(node.pRight, val);
                }
                else //If value = current node value => return that node
                {
                    return node;
                }
            }
        }

        public static int FindMax(Node node)
        {
            // Because the higher value always on the RIGHT, we only search on the right for
            // the max value
            if (node.pRight == null) //No node that have value higher than this
            {
                return node.value; // -> return the node value
            }
            return FindMax(node.pRight); //Or else, we find the next node with the higher value
        }
        public static int FindMin(Node node)
        {
            // The lower value always on the LEFT, we only search on the left for min value
            if (node.pLeft == null)
                return node.value;
            return FindMin(node.pLeft);
        }

        public static void NodeHas2(Node node)
        {
            if (node == null)
            {
                return;
            }
            if (node.pLeft != null && node.pRight != null)
            {
                Console.WriteLine(node.value + " has 2 children nodes");
            }
            NodeHas2(node.pLeft);  // Go check the next left node
            NodeHas2(node.pRight); // Go check the next right node
        }
        public static void NodeHas1(Node node)
        {
            if (node == null)
            {
                return;
            }
            if (node.pLeft == null && node.pRight != null || node.pLeft != null && node.pRight == null)
            {
                Console.WriteLine(node.value + " has 1 child nodes");
            }
            NodeHas1(node.pLeft);  // Go check the next left node
            NodeHas1(node.pRight); // Go check the next right node
        }
        public static void NodeHas0(Node node)
        {
            if (node == null)
            {
                return;
            }
            if (node.pLeft == null && node.pRight == null)
            {
                Console.WriteLine(node.value + " has NO children nodes");
            }
            NodeHas0(node.pLeft);  // Go check the next left node
            NodeHas0(node.pRight); // Go check the next right node
        }

        private static void FindReplaceMent(ref Node x, ref Node y)
        {
            /// Just go until we find the last node on the left
            if (y.pLeft != null)
            {
                var pLeft = y.pLeft;
                FindReplaceMent(ref x, ref pLeft);
                y.pLeft = pLeft;
            }
            else
            {
                // Replace the original node value with the most left node value
                // * Note that we keep the link intact
                // and then set the most left node to null
                x.value = y.value;
                y = y.pRight; // (y.pRight <=> null)
            }
        }
        public static void RemoveWithValue(ref Node root, int val)
        {
            if (root == null)
                return;
            if (root.value != val)
            {
                /// If the node value is != val
                /// and if val < node value, keep on looking on the left side of the Tree
                /// else (val > node value, keep on looking on the right
                if (val < root.value)
                {
                    /// Here we created another variable for pLeft and pRight
                    /// Because C# won't let us pass a propertie as ref or out
                    var pLeft = root.pLeft;
                    RemoveWithValue(ref pLeft, val);
                    root.pLeft = pLeft;
                }
                else
                {
                    var pRight = root.pRight;
                    RemoveWithValue(ref pRight, val);
                    root.pRight = pRight;
                }
            }
            else //Node value == val
            {
                // If this node is the "end" node (has no children node)
                // We gonna remove it
                if (root.pLeft == null && root.pRight == null)
                    root = null;

                // If this node has 2 children nodes
                else if (root.pLeft != null && root.pRight != null)
                {
                    /// We need to find a replacement node to fit in the tree
                    /// and then delete the node
                    /// a replacement node must maintain the logical order of the Tree
                    /// - It can be the "most left" node on the RIGHT side of the Tree
                    /// - It can be the "most right" node on the LEFT side of the Tree
                    /// Here we are gonna find the "most left" node on the Right side of the Tree

                    //if (root.pRight.pRight != null) // Checking of there's a child node on the right to replace
                    //    FindReplaceMent(ref root, root.pRight);
                    //else // If not, we just search for replacement on the left
                    var pRight = root.pRight;
                    FindReplaceMent(ref root, ref pRight);
                    root.pRight = pRight;
                }

                // If this node has 1 child node
                else
                {
                    // Just replace the node with it's child
                    if (root.pLeft == null)
                        root = root.pRight;
                    else
                    {
                        root = root.pLeft;
                    }
                }
            }
        }
        #endregion

        #region Binary Search Tree Traverse
        public static void TraverseAll(Node tree)
        {
            Console.Write("NLR: ");
            Traverse_NLR(tree);
            Console.Write("\nNRL: ");
            Traverse_NRL(tree);
            Console.Write("\nLNR: ");
            Traverse_LNR(tree);
            Console.Write("\nRNL: ");
            Traverse_RNL(tree);
            Console.Write("\nLRN: ");
            Traverse_LRN(tree);
            Console.Write("\nRLN: ");
            Traverse_RLN(tree);
            Console.WriteLine();
        }
        public static void Traverse_NLR(Node root)
        {
            if (root == null)
                return;
            Console.Write(root.value + " ");
            Traverse_NLR(root.pLeft);
            Traverse_NLR(root.pRight);
        }
        public static void Traverse_NRL(Node root)
        {
            if (root == null)
                return;
            Console.Write(root.value + " ");
            Traverse_NRL(root.pRight);
            Traverse_NRL(root.pLeft);
        }
        public static void Traverse_LNR(Node root) // <=> Smallest to Largest
        {
            if (root == null)
                return;
            Traverse_LNR(root.pLeft);
            Console.Write(root.value + " ");
            Traverse_LNR(root.pRight);
        }
        public static void Traverse_RNL(Node root) // <=> Largest to Smallest
        {
            if (root == null)
                return;
            Traverse_RNL(root.pRight);
            Console.Write(root.value + " ");
            Traverse_RNL(root.pLeft);
        }
        public static void Traverse_LRN(Node root)
        {
            if (root == null)
                return;
            Traverse_LRN(root.pLeft);
            Traverse_LRN(root.pRight);
            Console.Write(root.value + " ");
        }
        public static void Traverse_RLN(Node root)
        {
            if (root == null)
                return;
            Traverse_RLN(root.pRight);
            Traverse_RLN(root.pLeft);
            Console.Write(root.value + " ");
        }
        #endregion    
    }
}
