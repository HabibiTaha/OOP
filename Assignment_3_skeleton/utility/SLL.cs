using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    public class SLL : LinkedListADT
    {
        public Node First { get; set; }
        private int count;

        public void Append(object data)
        {
            Node node = new Node(data);

            Node lastNode = GetLastNode();
            if (lastNode != null)
            {
                lastNode.Next = node;
                node.Prev = lastNode;

                count++;

                return;
            }

            Prepend(data);
        }

        public void Clear()
        {
            First = null;
        }

        public bool Contains(object data)
        {
            var node = First;
            while (node != null)
            {
                if (node.Value == data)
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public void Delete(int index)
        {
            Node node = GetNode(index);
            if (node == null)
            {
                return;
            }

            Node next = node.Next;
            Node prev = node.Prev;

            if (prev != null)
            {
                prev.Next = next;
            }

            if (next != null)
            {
                next.Prev = prev;
            }

            count--;
        }

        public int IndexOf(object data)
        {
            int index = 0;
            var node = First;
            while (node != null)
            {
                if (node.Value == data)
                {
                    return index;
                }

                node = node.Next;
                index++;
            }

            return index;
        }

        public void Insert(object data, int index)
        {
            if(index < 0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }
            if (index ==0)
            {
                Prepend(data);
            }
            else if(index ==(count -1))
            {
                Append(data);
            }
            else
            {
                Node currentNode = First;
                //set the supplied data 
                Node newNode = new Node(data);
                for (int i =0; i < index-1;i++)
                {
                    currentNode = currentNode.Next;
                    //set the inserted node's next value as 
                    //the currentnode's next value 
                    newNode.Next = currentNode.Next; //(e -> c)
                }
                currentNode.Next = newNode;
                newNode.Prev = currentNode;

                count++;
            }
 
            //throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return First == null;
        }

        public void Prepend(object data)
        {
            Node node = new Node(data);

            if (First == null)
            {
                First = node;
            }
            else
            {
                node.Next = First;
                First.Prev = node;

                First = node;
            }

            count++;
        }

        public void Replace(object data, int index)
        {
            //check if supplied index is -ve or larger than the size
            if (index < 0 || index > count - 1)
            {
                throw new IndexOutOfRangeException();
            }
            Node node = First;
            //object retrievedObject = Retrieve(index);
            for (int i = 0; i < index; i++)
            {
                // go thru each node until we find the supplied index
                node = node.Next;
            }
            // set the node's value = new value which is the supplied data
            node.Value = data;            
        }

        public object Retrieve(int index)
        {
            if (index < 0 || index > count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            int i = 0;
            Node node = First;
            while (i != index)
            {
                if (node.Next != null)
                {
                    node = node.Next;
                }

                i++;
            }

            return node.Value;
        }

        public int Size()
        {
            return count;
        }

        private Node GetLastNode()
        {
            if (First == null)
            {
                return null;
            }

            Node node = First;
            while (node != null)
            {
                if (node.Next == null)
                {
                    return node;
                }

                node = node.Next;
            }

            return null;
        }

        public Node GetNode(int index)
        {
            if (index < 0 || index > count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            int i = 0;
            Node node = First;
            while (i != index)
            {
                if (node.Next != null)
                {
                    node = node.Next;
                }

                i++;
            }

            return node;
        }
    }
}
