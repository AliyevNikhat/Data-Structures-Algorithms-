using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            
        }
    }
    class Node
    {
        public int Data {get; init;}
        private Node Next {get; set;}
        private Node Prev {get; set;}

        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
        }
    }
    class Doubly_Linked_List
    {
        private Node Head;
        private Node Tail;

        public Doubly_Linked_List()
        {
            Head = Tail = null;
        }
    }
}