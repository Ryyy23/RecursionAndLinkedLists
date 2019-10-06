namespace Exercises
{
    public class ListNode
    {
        public string Data;
        public ListNode Next;


        public ListNode(string data, ListNode next = null)
        {
            this.Data = data;
            this.Next = next;
        }

        public ListNode() { }
    }

    public class LinkedList
    {
        public ListNode Head;

        public LinkedList()
        {
            Head = null;
        }

        public void AddToEnd(string newData)
        {
            ListNode newNode = new ListNode(newData, null);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            ListNode current = Head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        public ListNode GetNodeAt(int index)
        {
            int count = 0;

            if (index < 0)
            {
                return null;
            }

            ListNode current = Head;
            while (count < index)
            {
                if (current.Next != null)
                {
                    current = current.Next;
                }
                else
                {
                    return null;
                }
                count++;
            }

            return current;
        }

        public bool Find(string searchTerm)
        {
            ListNode current = Head;

            while (current != null)
            {
                if (current.Data == searchTerm)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Returns the number of nodes in the Linked List
        /// </summary>
        /// <returns>int: count</returns>
        public int Count()
        {
            int Count = 1;
            ListNode Current = Head;
            while (Current.Next != null)
            {
                Count++;
                Current = Current.Next;
            }
            return Count;
        }

        public ListNode InsertNewListNode(string data, ListNode node)
        {
            ListNode next = node;
            return new ListNode(data, next);
        }

        /// <summary>
        /// Adds a node to the start of the list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>success: true</returns>
        public bool AddToStart(string data)
        {
            Head = InsertNewListNode(data, Head);
            return true;
        }

        /// <summary>
        /// add new node at index.  If index specified is greater than the size of the current list,
        /// adds nodes with null data in between.  Negative index will return false.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool AddNodeAt(string data, int index)
        {
            if (index < 1) return false;
            ListNode current = Head;
            ListNode previous = null;

            int i = 0;
            // stepping through each node 
            while (i < index)
            { 
                if (current.Next == null) break;
                previous = current;
                current = current.Next;
                i++;
            }
            // add mew node
            while (i < index)
            { 
                previous = current;
                current = new ListNode();
                previous.Next = current;
                i++;
            }

            previous.Next = InsertNewListNode(data, current);
            return true;
        }

        /// <summary>
        /// Delete node at index.  return false if node does not exist
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteNodeAt(int index)
        {
            ListNode current = Head;
            ListNode previous = null;
            for (int i = 0; i < index; i++)
            {
                if (current == null) break;
                previous = current;
                current = current.Next;
            }
            // node doesn't exist
            if (current == null)
            {
                return false;
            }
            previous.Next = current.Next;
            return true;
        }
    }
}