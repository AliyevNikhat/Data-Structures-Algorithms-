using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            Doubly_Linked_List list = new Doubly_Linked_List();
            list.AddFirst(12);
            list.AddFirst(10);
            list.AddFirst(8);
            list.AddMiddle(100);
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
        public void AddLast(int data)
        {
            Node current = new Node(data);
            if(Head == null)
            {
                Head = Tail = current;
            }
            else
            {
                current.Prev = Tail;
                Tail.Next = current;
                Tail = current;
            }
        }
        public void AddMiddle(int data)
        {
            Node current = new Node(data);
            if(Head == null)
            {
                Head = Tail = current;
            }
            else
            {
                double LinkedListCount = GetDoublyLinkedListCount() / 2.0; 
                LinkedListCount = Math.Ceiling(LinkedListCount);
                Node temp = Head;
                while(LinkedListCount > 1)
                {
                    temp = temp.Next;
                    LinkedListCount--;
                }
                current.Next = temp.Next;
                temp.Next = current;
                temp.Next.Prev = current;
                current.Prev = temp;
                temp = current;
            }
        }
        public int GetDoublyLinkedListCount()
        {
            Node temp = Head;
            int DoublyLinkedList = 0;
            while(temp != null)
            {
                DoublyLinkedList++;
                temp = temp.Next;
            }
            return DoublyLinkedList;
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