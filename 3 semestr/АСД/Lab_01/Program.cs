using System.Text;

namespace Lab_01
{
    public class LinkedList<T>
    {
        private class Node
        {
            public Node(T t)
            {
                Previous = null;
                Data = t;
            }

            public Node? Previous { get; set; }
            public T Data { get; set; }
        }

        private Node? _head;

        public int Lenght => GetEnumerator().Count();

        public LinkedList()
        {
            _head = null;
        }

        public void AddHead(T t)
        {
            Node n = new(t)
            {
                Previous = _head
            };
            _head = n;
        }

        public T GetHead()
        {
            return _head.Data;
        }

        public void RemoveHead()
        {
            if (_head is null) return;
            _head = _head.Previous;
        }

        public IEnumerable<T> GetEnumerator()
        {
            Node? current = _head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

        public T? FindMin()
        {
            if (_head is null || _head.Data is null) return default;
            if (_head.Data is not IComparable) return default;

            var list = GetEnumerator().ToArray();
            T? min = default;
            if (_head.Data is string) min = _head.Data;
            foreach (T? item in list)
            {
                if (item is not IComparable itemComparable) continue;
                var minComparable = min as IComparable;
                var result = itemComparable.CompareTo(minComparable);
                if (result < 0) min = item;
            }

            return min;
        }

        public override string ToString()
        {
            var list = GetEnumerator();
            string b = "";
            foreach (T i in list)
            {
                b += Convert.ToString(i);
                b += ", ";
            }

            b = b[..^2];

            return b;
        }
    }

    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            LinkedList<int> intList = new();

            for (int x = 0; x < 10; x++)
            {
                intList.AddHead(x);
            }

            Console.WriteLine("Виведення пов'язаного списку:\n" + intList);

            Console.WriteLine("\nВивід довжини пов'язаного списку:\n" + intList.Lenght);
            Console.WriteLine("\nЩоб дізнатись чи список пустий можна дізнатись його довжину та, якщо вона більше 0, то він не пустий");
            Console.WriteLine("\nВиведення першого елементу із пов'язаного списку:\n" + intList.GetHead());
            intList.RemoveHead();
            Console.WriteLine("\nВидалення елементу із пов'язаного списку:\n" + intList);
            Console.WriteLine("\nЗнаходження мінімального елементу пов'язаного списку:\n" + intList.FindMin());


            LinkedList<string> stringList = new();
            stringList.AddHead("a");
            stringList.AddHead("b");
            stringList.AddHead("c");
            Console.WriteLine("\nВиведення пов'язаного списку складеного із рядків:\n" + stringList);
            Console.WriteLine("\nЗнаходження мінімального елементу пов'язаного списку складеного із рядків\n" + stringList.FindMin());
        }
    }
}