namespace BinarySearchTree
{
    public class Node
    {
        public int value { get; set; }
        public Node pLeft { get; set; }
        public Node pRight { get; set; }

        public Node(int _value)
        {
            value = _value;
        }

        public Node() { }
    }
}
