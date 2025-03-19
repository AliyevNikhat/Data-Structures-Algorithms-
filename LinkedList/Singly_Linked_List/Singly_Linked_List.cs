using System;
using System.Runtime.Serialization;

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
            Dictionary<string, Func<int, bool>> SpecificNodeRemover = new Dictionary<string, Func<int, bool>>()
            {
                {"7", list.RemoveNodeByValue},
                {"8", list.RemoveNodeByIndex}
            } ;
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
                bool CheckInvalid = false;;
                ConsoleApp();
                string choice = Console.ReadLine();
                    if(choice == "0") { noParamMenu[choice].Invoke(); break;}
                if(menu.ContainsKey(choice))
                {
                    System.Console.Write("Number : "); int ChoiceNumberForLinkedList = int.Parse(Console.ReadLine());
                    menu[choice].Invoke(ChoiceNumberForLinkedList);
                }
                else if(SpecificNodeRemover.ContainsKey(choice))
                {
                    System.Console.Write("Number : "); int ChoiceNumberForLinkedList = int.Parse(Console.ReadLine());
                    CheckInvalid = SpecificNodeRemover[choice].Invoke(ChoiceNumberForLinkedList);
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
                if((choice == "7" || choice == "8") && CheckInvalid == false)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("----INVALID----");
                }
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
            System.Console.WriteLine("7 - To Remove a Specific Value in LinkedList!");
            System.Console.WriteLine("8 - To Remove a Specific Index in LinkedList!");
            System.Console.WriteLine("0 -  To Exit.");
            System.Console.Write("Enter Number (1 - 5) : ");
        }
    }
    class Node
    {
        /// <summary>
        /// This is the value of the node.
        /// </summary>
        public int Data { get; init;}
        /// <summary>
        /// This is the next node.
        /// </summary>
        private Node? Next {get; set;}
        /// <summary>
        /// Creates a new node with the given value.
        /// </summary>
        /// <param name="data">The value of the node.</param>
        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
        }
        /// <summary>
        /// Sets the next node.
        /// </summary>
        /// <param name="NextElement">The next node to link.</param>
        public void SetNextElement(Node NextElement)
        {
            this.Next = NextElement;
        }
        /// <summary>
        /// Gets the next node.
        /// </summary>
        /// <returns>The next node or null if there is no next node.</returns>
        public Node? GetNextElement()
        {
            return this.Next;
        }
    }
    class Singly_Linked_List
    {
        /// <summary>
        /// This is the first node in the list.
        /// </summary>
        private Node? Head;
        /// <summary>
        /// Creates an empty linked list.
        /// </summary>
        public Singly_Linked_List()
        {
            this.Head = null;
        }
        /// <summary>
        /// Adds a new node to the end of the list.
        /// </summary>
        /// <param name="data">The value of the new node.</param>
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
        /// <summary>
        /// Displays all elements in the linked list.
        /// </summary>
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
        /// <summary>
        /// Adds a new node to the beginning of the list.
        /// </summary>
        /// <param name="data">The value of the new node.</param>
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
        /// <summary>
        /// Adds a new node to the middle of the list.
        /// </summary>
        /// <param name="data">The value of the new node.</param>
        public void AddMiddle(int data)
        {
            Node current = new Node(data);
            if(Head == null)
            {
                Head = current;
            }
            else
            {
                int MiddleOfLinkedList = (int)Math.Ceiling(GetCount_LinkedList() / 2.0);
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
        /// <summary>
        /// Counts the number of nodes in the list.
        /// </summary>
        /// <returns>The total number of nodes in the list.</returns>
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
        /// <summary>
        /// Removes the first element from the list.
        /// </summary>
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
        /// <summary>
        /// Removes the last element from the list.
        /// </summary>
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
        /// <summary>
        /// Reverses the order of the elements in the list.
        /// </summary>
        public void ReverseLinkedList(Singly_Linked_List list)
        {
            Node? prev = null;
            Node? current = Head;
            while (current != null)
            {
                Node? nextNode = current.GetNextElement();
                current.SetNextElement(prev);
                prev = current;
                current = nextNode;
            }
            Head = prev;
        }
        /// <summary>
        /// Removes the first node with the specified value from the list.
        /// </summary>
        /// <param name="data">The value of the node to remove.</param>
        /// <returns>True if the node was removed; otherwise, false.</returns>
        public bool RemoveNodeByValue(int data)
        {
            if(Head == null)
            {
                return false;
            }
            else if(Head.Data == data)
            {
                Head = Head.GetNextElement();
                return true;
            }
            else
            {
                Node current = Head;
                Node prev = null;
                while(current != null)
                {
                    if(current.Data == data)    
                    {
                        prev.SetNextElement(current.GetNextElement());
                        return true;
                    }
                    prev = current;
                    current = current.GetNextElement();
                }
            }
            return false;
        }
        /// <summary>
        /// Removes a node from the linked list at the specified index.
        /// If the index is invalid or the list is empty, it returns false.
        /// If the index is 0, it removes the first node.
        /// Otherwise, it traverses the list and removes the node at the specified index.
        /// </summary>
        /// <param name="index">The index of the node to be removed.</param>
        /// <returns>Returns true if the node was successfully removed, otherwise false.</returns>
        public bool RemoveNodeByIndex(int index)
        {
            if (Head == null || index < 0 || index >= GetCount_LinkedList())
            {
                return false;
            }
            if (index == 0)
            {
                Head = Head.GetNextElement();
                return true;
            }

                Node current = Head;
                Node prev = current;
                int LinkedListIndex = 0;
                while(current != null)
                {
                    if(LinkedListIndex == index)
                    {
                        if (prev != null)
                        {
                            prev.SetNextElement(current.GetNextElement());
                        }
                        return true;
                    }
                    prev = current;
                    current = current.GetNextElement();
                    LinkedListIndex++;
                }
            return false;
        }
    }
}