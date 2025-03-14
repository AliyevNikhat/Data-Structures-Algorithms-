using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            Singly_Linked_List list = new Singly_Linked_List();
            // I am testing the LinkedList by adding elements and performing operations on it.
                list.AddFirst(13);
                list.AddFirst(15);
                list.AddFirst(11);
                list.AddFirst(10);
                list.AddMiddle(122);
                list.RemoveLastElemnt();
                System.Console.WriteLine(list.GetCount_LinkedList());
                list.ShowInfo();
               
            // If there is only one element in the LinkedList, the RemoveFirstElement and RemoveLastElement methods will work properly.
        }
    }
    class Node
    {
        public int Data { get; init;}
        private Node? Next {get; set;}
        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
        }
        public void SetNextElement(Node NextElement)
        {
            this.Next = NextElement;
        }
        public Node? GetNextElement()
        {
            return this.Next;
        }
    }
    class Singly_Linked_List
    {
        private Node? Head;
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
                while(temp.GetNextElement() != null)
                {
                    temp = temp.GetNextElement();
                }
                temp.SetNextElement(current);
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
                    temp = temp.GetNextElement();
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
                current.SetNextElement(Head);
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
                double MiddleOfLinkedList = GetCount_LinkedList() / 2.0;
                Math.Ceiling(MiddleOfLinkedList);
                Node temp = Head;
                while(MiddleOfLinkedList > 1)
                {
                    MiddleOfLinkedList--;
                    temp = temp.GetNextElement();
                }
                current.SetNextElement(temp.GetNextElement());
                temp.SetNextElement(current);
            }
        }
        public int GetCount_LinkedList()
        {
            Node temp = Head;
            int LinkedListCount = 0;
            while(temp != null)
            {
                temp = temp.GetNextElement();
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
                Head = Head.GetNextElement();                 
            }
        }
        public void RemoveLastElemnt()
        {
            if(Head == null || Head.GetNextElement() == null)
            {
                Head = null;
            }
            else
            {
                Node temp = Head;
                while(temp.GetNextElement()?.GetNextElement() != null)
                {
                    temp = temp.GetNextElement();
                }
                temp.SetNextElement(null); 
            }
        }
    }
}