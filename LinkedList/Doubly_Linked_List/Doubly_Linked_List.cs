using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            Doubly_Linked_List list = new Doubly_Linked_List();
            list.AddFirst(10);            
            list.AddFirst(9);            
            list.AddFirst(8);
            list.ShowInfo();

        }
    }
    class Node
    {
        public int Data {get; init;}
        public Node Next {get; set;}
        public Node Prev {get; set;}

        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
        }
    }
    class Doubly_Linked_List
    {
        public Node Head;
        public Node Tail;

        public Doubly_Linked_List()
        {
            Head = Tail = null;
        }

        public void AddFirst(int data)
        {
            Node current = new Node(data);
            if(Head == null)
            {
                Head = Tail = current;
            }
            else
            {
                current.Next = Head;
                Head.Prev = current;
                Head = current;
            }
        }

        public void ShowInfo()
        {
            Node temp = Head;
            while(temp != null)
            {
                System.Console.Write($"{temp.Data} --->> ");
                temp = temp.Next;
            }   
            System.Console.WriteLine("NULL");
        }
    }
}