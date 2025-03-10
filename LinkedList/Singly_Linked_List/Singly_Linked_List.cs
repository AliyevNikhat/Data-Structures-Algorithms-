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
            list.AddFirst(46);
            list.ShowInfo();
            System.Console.WriteLine();
            list.AddMiddle(1000);
            System.Console.WriteLine("----------UPDATED----------");
            list.ShowInfo(); // Added an element in the middle of the LinkedList
            System.Console.WriteLine();
            list.RemoveFirstElement(); //Removed the first element in the LinkedList
            // System.Console.WriteLine(list.GetCount_LinkedList());
            System.Console.WriteLine("----------UPDATED----------");
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
                System.Console.WriteLine("There is no element in the singly linked list!");
            }
            else
            {
                Node temp = Head;
                while(temp != null)
                {
                    System.Console.Write($"{temp.Data} --->>> ");
                    temp = temp.Next;
                }
                System.Console.Write("NULL");
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
        public void AddMiddle(int data)
        {
            Node current = new Node(data);
            if(Head == null)
            {
                Head = current;
            }
            else
            {
                int MiddleOfLinkedList = GetCount_LinkedList() / 2;
                Node temp = Head;
                while(MiddleOfLinkedList > 1)
                {
                    temp = temp.Next;
                    MiddleOfLinkedList--;
                }
                current.Next = temp.Next;
                temp.Next = current;
            }
        }
        public int GetCount_LinkedList()
        {
            Node temp = Head;
            int LinkedListCount = 0;
            while(temp != null)
            {
                temp = temp.Next;
                LinkedListCount++;
            }
            return LinkedListCount;
        }
        public void RemoveFirstElement()
        {
            if(Head == null)
            {
                System.Console.WriteLine("There is no element in the singly linked list!");
            }
            else
            {
                Head = Head.Next;
            }
        }
    }
}