using System;
using System.Collections.Generic;
namespace Task4 {

    class Node {

        public int Data { get; private set; }

        public Node Next { get; set; }

        public Node(int data) {
            this.Data = data;
        }



        public override string ToString() {
            return $"{this.Data} - {this.Next}";
        }
    }

    class LinkedList {
        public Node Head { get; private set; }

        public Node Tail { get; private set; }

        public int Count { get; private set; }

        public void Add(int value) {
            Node node = new Node(value);
            if (this.Head == null) {
                this.Head = node;
            } else {
                this.Tail.Next = node;
            }
            this.Tail = node;
            ++(this.Count);
        }

        public void Print() {
            Node current = this.Head;
            while (current != null) {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public bool Contains(int value) {
            Node current = this.Head;
            while (current != null && current.Data != value) {
                current = current.Next;
            }
            return (current == null) ? false : true;
        }

        public void AppendFirst(int value) {
            Node newFirstNode = new Node(value);
            newFirstNode.Next = this.Head;
            this.Head = newFirstNode;
            if (this.Count == 0) {
                this.Tail = this.Head;
            }
            ++(this.Count);
        }
        public void Clear() {
            this.Head = null;
            this.Tail = null;
            this.Count = 0;
        }
        public Node Max() {
            Node current = this.Head;
            int max_value = int.MinValue;
            Node max_node = this.Head;
            while (current != null) {
                if (current.Data > max_value)
                {
                    max_value = current.Data;
                    max_node = current;
                }
                current = current.Next;

            }
            return max_node;
        }

        public bool Remove(int value) {
            Node prevNode = null;
            Node current = this.Head;
            while (current != null && current.Data != value)
            {
                prevNode = current;
                current = current.Next;
            }
            if (current == null) {
                return false;
            }
            else  /*(current.Data == value)*/ {
                if (current == this.Head) {
                    this.Head = this.Head.Next;
                } else if (current == this.Tail) {
                    prevNode.Next = null;
                } else {
                    prevNode.Next = current.Next;
                    current = null;
                }
                --(this.Count);
                return true;
            }
        }

        public void Reverse() {
            Stack<Node> revStack = new Stack<Node>();
            Node current = this.Head;
            while (current != null) {
                revStack.Push(current);
                current = current.Next;
            }
            LinkedList reversed = new LinkedList();
            while(revStack.Count > 0) {
                reversed.Add(revStack.Pop().Data);
            }
            this.Head = reversed.Head;
            this.Count = reversed.Count;
            this.Tail = reversed.Tail;
        }
    }

    class Program {
        static void Main()
        {
            
        }
    }
}

/* Решение с семинара:
using System;
using System.Collections.Generic;
 
namespace Task
{​​​​
    class Node
    {​​​​
        public Node(int data)
        {​​​​
            Data = data;
        }​​​​
        public int Data {​​​​ get; set; }​​​​
        public Node Next {​​​​ get; set; }​​​​
        public override string ToString()
        {​​​​
            return $"{​​​​Data}​​​​"; // !!!
            //return $"{​​​​Data}​​​​ - {​​​​Next}​​​​"; // !!!
        }​​​​
    }​​​​
 
    class LinkedList
    {​​​​
        public Node Head {​​​​ get; set; }​​​​
        public Node Tail {​​​​ get; set; }​​​​
        public int Count {​​​​ get; set; }​​​​
 
        public void Add(int value)
        {​​​​
            Node node = new Node(value);
            if (Head == null)
                Head = node;
            else
                Tail.Next = node;
            Tail = node;
            Count++;
        }​​​​
 
        public void Print()
        {​​​​
            Node current = Head;
            while(current != null)
            {​​​​
                Console.WriteLine(current);
                current = current.Next;
            }​​​​
        }​​​​
        public void Clear() //чистит список
        {​​​​
            Head = null;
            Tail = null;
            Count = 0;
        }​​​​
 
        public bool Contains(int data) // ищет есть ли указанный элемент
        {​​​​
            Node current = Head;
            while (current != null)
            {​​​​
                if (current.Data == data)
                    return true;
                current = current.Next;
            }​​​​
            return false;
        }​​​​
 
        public void AppendFirst(int data) // добавляет элемент в начало списка
        {​​​​
            Node node = new Node(data);
            node.Next = Head;
            Head = node;
            if (Count == 0)
                Tail = Head;
            Count++;
        }​​​​
 
        public Node Max()
        {​​​​
            Node current = Head;
            Node max = null;
            while (current != null)
            {​​​​
                if (max == null)
                    max = current;
                else if (max.Data < current.Data)
                    max = current;
                current = current.Next;
            }​​​​
            return max;
        }​​​​
 
        public bool Remove(int data)
        {​​​​
            Node current = Head;
            Node prev = null;
 
            while (current != null)
            {​​​​
                if (current.Data == data)
                {​​​​
                    // если узел в середине или в конце
                    if (prev != null)
                    {​​​​
                        prev.Next = current.Next;
                        if (current.Next == null)
                            Tail = prev;
                    }​​​​
                    else // узел в начале
                    {​​​​
                        Head = Head.Next;
                    }​​​​
                    if (Head == null)
                        Tail = null;
                    Count--;
                    return true;
                }​​​​
                prev = current;
                current = current.Next;
            }​​​​
 
            return false;
        }​​​​
 
        public void Reverse()
        {​​​​
            // перевернуть список
            // 1 2 3 4 -> 4 3 2 1
            Node curr = Head,
                 next = null,
                 prev = null;
            Tail = Head;
            while (curr != null)
            {​​​​
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }​​​​
            Head = prev;
        }​​​​
    }​​​​
    class Program
    {​​​​
        public static void Main()
        {​​​​
            LinkedList linkedList = new LinkedList();
            linkedList.Add(1);
            linkedList.Remove(1);
            linkedList.Print();
        }​​​​
    }​​​​
}​​​​
*/
