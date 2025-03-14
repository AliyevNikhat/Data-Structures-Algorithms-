using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            Singly_Linked_List list = new Singly_Linked_List();
            int EnterNumber = ConsoleApp();
            int NumberForLinkedList;
            while(EnterNumber != 0)
            {
                switch (EnterNumber)
                {
                    case 1: Console.Write("Number : "); NumberForLinkedList = int.Parse(Console.ReadLine());
                        list.AddLast(NumberForLinkedList);
                        break;
                    case 2: System.Console.Write("Number : "); NumberForLinkedList = int.Parse(Console.ReadLine());
                        list.AddFirst(NumberForLinkedList);
                        break;
                    case 3: Console.Write("Number : "); NumberForLinkedList = int.Parse(Console.ReadLine());
                        list.AddMiddle(NumberForLinkedList);
                        break;
                    case 4:
                        list.RemoveFirstElement();
                        break;
                    case 5:
                        list.RemoveLastElement();
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("You Entered the Wrong Case");
                        break;
                }
                Console.Clear();
                list.ShowInfo();
                EnterNumber = ConsoleApp();

            }               
        }
        static int ConsoleApp()
        {
            int EnterNumber;
            System.Console.WriteLine("\n1 - To Add the Last Element in a LinkedList !");
            System.Console.WriteLine("2 - To Add the First Element in a Linkedlist !");
            System.Console.WriteLine("3 - To Add the Middle Element in a Linkedlist !");
            System.Console.WriteLine("4 - To Remove the First Element in a Linkedlist !");
            System.Console.WriteLine("5 - To Remove the Last Element in a Linkedlist !");
            System.Console.WriteLine("0 -  To Exit.");
            System.Console.Write("Enter Number (1 - 5) : "); EnterNumber = int.Parse(Console.ReadLine());
            return EnterNumber;
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
                while(temp?.GetNextElement() != null)
                {
                    temp = temp.GetNextElement();
                }
                temp?.SetNextElement(current);
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
                Head = null;
            }
            else
            {
                Head = Head.GetNextElement();                 
            }
        }
        public void RemoveLastElement()
        {
            if(Head == null || Head.GetNextElement() == null)
            {
                Head = null;
            }
            else
            {
                Node temp = Head;
                while(temp?.GetNextElement()?.GetNextElement() != null)
                {
                    temp = temp.GetNextElement();
                }
                temp.SetNextElement(null); 
            }
        }
    }
}