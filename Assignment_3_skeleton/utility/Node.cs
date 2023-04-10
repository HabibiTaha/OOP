using System;

namespace Assignment_3_skeleton
{
    public class Node
    {
        public Object Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(Object value)
        {
            Value = value;
        }
    }
}
