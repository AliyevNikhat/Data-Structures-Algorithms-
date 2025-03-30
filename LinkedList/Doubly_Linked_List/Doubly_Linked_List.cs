using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            Doubly_Linked_List list = new Doubly_Linked_List();
        }
    }
    
    /// <summary>
    /// Represents a node in a doubly linked list.
    /// </summary>
    class Node
    {
        /// <summary>
        /// Gets the data stored in the node. Read-only.
        /// </summary>  
        public int Data {get; init;}
        private Node Next {get; set;}
        private Node Prev {get; set;}
        /// <summary>   
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="data">The value to be stored in the node.</param>

        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
        }
        /// <summary>
        /// Sets the next node in the list.
        /// </summary>
        /// <param name="NextNode">The node to set as next.</param>
        public void SetNext(Node NextNode)
        {
            this.Next = NextNode;
        }

        /// <summary>
        /// Gets the next node in the list.
        /// </summary>
        /// <returns>The next node.</returns>
        public Node GetNext()
        {
            return this.Next;
        }

        /// <summary>
        /// Sets the previous node in the list.
        /// </summary>
        /// <param name="PrevNode">The node to set as previous.</param>
        public void SetPrev(Node PrevNode)
        {
            this.Prev = PrevNode;
        }

        /// <summary>
        /// Gets the previous node in the list.
        /// </summary>
        /// <returns>The previous node.</returns>
        public Node GetPrev()
        {
            return this.Prev;
        }
    }

    /// <summary>
    /// Represents a doubly linked list.
    /// </summary>
    class Doubly_Linked_List
    {
        /// <summary>
        /// The head of the list.
        /// </summary>
        public Node Head;

        /// <summary>
        /// The tail of the list.
        /// </summary>
        public Node Tail;

        /// <summary>
        /// Initializes an empty doubly linked list.
        /// </summary>
        public Doubly_Linked_List()
        {
            Head = Tail = null;
        }

        /// <summary>
        /// Adds a node with the given data at the beginning of the list.
        /// </summary>
        /// <param name="data">The value to be added.</param>
        public void AddFirst(int data)
        {
            Node current = new Node(data);
            if(Head == null)
            {
                Head = Tail = current;
            }
            else
            {
                current.SetNext(Head);
                Head.SetPrev(current);
                Head = current;
            }
        }

        /// <summary>
        /// Adds a node with the given data at the end of the list.
        /// </summary>
        /// <param name="data">The value to be added.</param>
        public void AddLast(int data)
        {
            Node current = new Node(data);
            if(Head == null)
            {
                Head = Tail = current;
            }
            else
            {
                current.SetPrev(Tail);
                Tail.SetNext(current);
                Tail = current;
            }
        }

        /// <summary>
        /// Adds a node with the given data in the middle of the list.
        /// </summary>
        /// <param name="data">The value to be added.</param>
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
                    temp = temp.GetNext();
                    LinkedListCount--;
                }
                current.SetNext(temp.GetNext());
                temp.SetNext(current);
                temp.GetNext().SetPrev(current);
                current.SetPrev(temp);
                temp = current;
            }
        }

        /// <summary>
        /// Returns the number of nodes in the list.
        /// </summary>
        /// <returns>The total count of nodes.</returns>
        public int GetDoublyLinkedListCount()
        {
            Node temp = Head;
            int DoublyLinkedList = 0;
            while(temp != null)
            {
                DoublyLinkedList++;
                temp = temp.GetNext();
            }
            return DoublyLinkedList;
        }

        /// <summary>
        /// Removes the first node from the list.
        /// </summary>
        public void RemoveFirstElement()
        {
            if(Head == null)
            {
                System.Console.WriteLine("There is no element in Doubly LinkedList !");
            }
            else if(Head.GetNext() == null)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.GetNext();
            }
        }

        /// <summary>
        /// Removes the last node from the list.
        /// </summary>
        public void RemoveLastElement()
        {
            if(Head == null)
            {
                System.Console.WriteLine("There is no element in Doubly LinkedList !");
            }
            else if(Head.GetNext() == null)
            {
                Head = Tail = null;
            }
            else
            {
                Tail = Tail.GetPrev(); 
                Tail.SetNext(null);
            }
        }

        /// <summary>
        /// Displays all the nodes in the list.
        /// </summary>
        public void ShowInfo()
        {
            Node temp = Head;
            while(temp != null)
            {
                System.Console.Write($"{temp.Data} --->> ");
                temp = temp.GetNext();
            }   
            System.Console.Write("NULL");
        }
    }
}