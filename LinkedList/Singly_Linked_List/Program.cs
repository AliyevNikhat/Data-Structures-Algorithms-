using System;

namespace DataStructures_Singly_LinkedList
{
    class Program
    {
        static void Main()
        {
            Singly_LinkedList list = new Singly_LinkedList();
            list.Addlast(12);
            list.Addlast(15);
            list.Addlast(18);
            list.AddFirst(9);
            list.AddMiddle(16);
            list.ShowInfo();
            list.RemoveFirst();
            Console.WriteLine();
            list.ShowInfo();
        }
    }
    class Node
    {
        public int Data {get; }
        public Node? Next {get; set;}
        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
    class Singly_LinkedList
    {
        private Node? Head;

        public Singly_LinkedList()
        {
            this.Head = null;
        }

        public void Addlast(int data)
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
        public void ShowInfo()
        {
            Node? temp = Head;
            while(temp!=null)
            {
                System.Console.Write($"{temp.Data} --->> ");
                temp = temp.Next;
            }
            System.Console.Write("NULL");
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
                int middle = GetLinkedListCount() / 2;
                Node temp = Head;
                while(middle > 1)
                {
                    temp = temp.Next;
                    middle--;
                }
                current.Next = temp.Next;
                temp.Next = current;
            }
        }
        public int GetLinkedListCount()
        {
            Node temp = Head;
            int count = 0;
            while(temp != null)
            {
                count++;
                temp = temp.Next;
            }
            return count;
        }
        public void RemoveFirst()
        {
            if(Head == null)
            {
                throw new Exception("There is not Element in Singly LinkedList !!");
            }
            else
            {
                Head = Head.Next;
            }
        }
    }
    
}