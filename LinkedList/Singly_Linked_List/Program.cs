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
            list.ShowInfo();
        }
    }
    class Node
    {
        public int Data {get; }
        public Node? Next {get; private set;}
        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
        }

        public void SetNext(Node NextNode)
        {
            this.Next = NextNode;
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
                temp.SetNext(current);
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
                current.SetNext(Head);
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

    }
    
}