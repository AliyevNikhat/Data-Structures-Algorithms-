using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            Singly_Linked_List list = new Singly_Linked_List();
            Dictionary<string, Action<int>> menu = new Dictionary<string, Action<int>>()
            {
                {"1", list.AddLast},
                {"2", list.AddFirst},
                {"3", list.AddMiddle},
            };
            Dictionary<string, Action<Singly_Linked_List>> ReverseLinkedList = new Dictionary<string, Action<Singly_Linked_List>>()
            {
                {"6", list.ReverseLinkedList}
            };
            Dictionary<string, Action> noParamMenu = new Dictionary<string, Action>()
            {
                {"4", list.RemoveFirstElement},
                {"5", list.RemoveLastElement},
                {"0", () => 
                {
                    System.Console.WriteLine("Exiting the application...");
                    Environment.Exit(0);
                }}
            };

            while(true)
            {
                ConsoleApp();
                string choice = Console.ReadLine();
                    if(choice == "0") { noParamMenu[choice].Invoke(); break;}
                if(menu.ContainsKey(choice))
                {
                    System.Console.Write("Number : "); int ChoiceNumberForLinkedList = int.Parse(Console.ReadLine());
                    menu[choice].Invoke(ChoiceNumberForLinkedList);
                }
                else if(noParamMenu.ContainsKey(choice))
                {
                    noParamMenu[choice].Invoke();
                }
                else if(ReverseLinkedList.ContainsKey(choice))
                {
                    ReverseLinkedList[choice].Invoke(list);
                }
                Console.Clear();
                list.ShowInfo();
            }
        }
        static void ConsoleApp()
        {
            System.Console.WriteLine("\n1 - To Add the Last Element in a Linkedlist !");
            System.Console.WriteLine("2 - To Add the First Element in a Linkedlist !");
            System.Console.WriteLine("3 - To Add the Middle Element in a Linkedlist !");
            System.Console.WriteLine("4 - To Remove the First Element in a Linkedlist !");
            System.Console.WriteLine("5 - To Remove the Last Element in a Linkedlist !");
            System.Console.WriteLine("6 - To Reverse in Linkedlist !");
            System.Console.WriteLine("0 -  To Exit.");
            System.Console.Write("Enter Number (1 - 5) : ");
        }
    }
    class Node
    {
        public int Data { get; init;}
        public Node? Next {get; set;}
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
        public Node? Head;
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
        public void ReverseLinkedList(Singly_Linked_List list)
        {
            Node? prev = null;
            Node? current = Head;
            while (current != null)
            {
                Node? nextNode = current.Next; // Next-ə bu şəkildə erişmək lazımdır
                current.Next = prev;
                prev = current;
                current = nextNode;
            }
            Head = prev;
        }
    }
}