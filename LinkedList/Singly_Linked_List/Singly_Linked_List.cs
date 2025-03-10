using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            Singly_Linked_List list = new Singly_Linked_List();
            list.AddLast(12);
            list.AddLast(15);
            list.AddLast(18);
            list.AddLast(21);
            list.AddFirst(9);
            list.ShowInfo();
        }
    }
    class Node
    {
        public int Data { get; }
        public Node? Next {get; set;}
        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
    class Singly_Linked_List
    {
        Node? Head;
        public Singly_Linked_List()
        {
            this.Head = null;
        }
        public void AddLast(int data)
        {
            Node current = new Node(data);
            if(Head == null)
            {
                Head = current;
            }
            else
            {
                Node temp = Head;
                while(temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = current;
            }
        }
        public void ShowInfo()
        {
            if(Head == null)
            {
                System.Console.WriteLine("There is not Element in Singly_LinedList!");
            }
            else
            {
                Node temp = Head;
                while(temp != null)
                {
                    System.Console.Write($"{temp.Data} --->>> ");
                    temp = temp.Next;
                }
                System.Console.Write(" NULL");
            }
        }
        public void AddFirst(int data)
        {
            Node current = new Node(data);
            if(Head == null)
            {
                Head = current;
            }
            else
            {
                current.Next = Head;
                Head = current;
            }
        }
    }
}