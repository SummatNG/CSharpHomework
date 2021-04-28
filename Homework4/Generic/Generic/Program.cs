using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intList = new GenericList<int>();

            for (int x = 0; x < 10; x++)
            {
                intList.Add(x);
            }
            //逐步打印
            intList.ForEach(x => Console.WriteLine(x));

            //最大值
            int max = int.MinValue;
            intList.ForEach(x => { if (max < x) max = x; });
            Console.WriteLine($"Max: {max}");

            //最小值
            int min = int.MaxValue;
            intList.ForEach(x => { if (min > x) min = x; });
            Console.WriteLine($"Min: {min}");

            //总和
            int sum = 0;
            intList.ForEach(x => { sum += x; });
            Console.WriteLine($"Sum: {sum}");

        }

        public class Node<T>
        {
            public Node<T> Next { get; set; }
            public T data { get; set; }

            public Node(T t)
            {
                Next = null;
                data = t;
            }
        }

        public class GenericList<T>
        {
            private Node<T> head;
            private Node<T> tail;

            public GenericList()
            {
                tail = head = null;
            }

            public Node<T> Head
            {
                get
                {
                    return head;
                }
            }

            public void Add(T t)
            {
                Node<T> n = new Node<T>(t);
                if (tail == null)
                {
                    head = tail = n;
                }
                else
                {
                    tail.Next = n;
                    tail = tail.Next;
                }
            }

            public void ForEach(Action<T> action)
            {
                for (Node<T> t = head; t != null; t = t.Next)
                {
                    action(t.data);
                }
            }
        }
    }
}

