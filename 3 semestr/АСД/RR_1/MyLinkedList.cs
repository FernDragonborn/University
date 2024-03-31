using System.Text;

namespace RR_1;
public class MyLinkedList<T>
{
    public MyLinkedList()
    {
        _head = null;
    }

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

    public bool IsEmpty => _head == null;

    public void AddHead(T t)
    {
        Node node = new(t)
        {
            Previous = _head
        };
        _head = node;
    }

    public T? GetHead()
    {
        return IsEmpty ? default : _head.Data;
    }

    public bool TryRemoveHead()
    {
        if (IsEmpty) return false;
        _head = _head.Previous;
        return true;
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
        if (IsEmpty || _head.Data is null) return default;
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
        if (IsEmpty) return "no elements";
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
        MyLinkedList<int> intList = new();
        MyLinkedList<int> emptyList = new();

        for (int x = 0; x < 10; x++)
        {
            intList.AddHead(x);
        }

        Console.WriteLine("Виведення пов'язаного списку:\n" + intList);

        Console.WriteLine("\nВивід довжини пов'язаного списку:\n" + intList.Lenght);
        Console.WriteLine("\nВиведення чи пустий список\n" + intList.IsEmpty);
        Console.WriteLine("\nВиведення першого елементу із пов'язаного списку:\n" + intList.GetHead());
        Console.WriteLine("\nВиведення першого елементу із пустого списку:\n" + emptyList.GetHead());
        intList.TryRemoveHead();
        Console.WriteLine("\nВидалення елементу із пов'язаного списку:\n" + intList);
        emptyList.TryRemoveHead();
        Console.WriteLine("\nВидалення елементу із пустого списку:\n" + emptyList);
        Console.WriteLine("\nЗнаходження мінімального елементу пов'язаного списку:\n" + intList.FindMin());


        MyLinkedList<string> stringList = new();
        stringList.AddHead("a");
        stringList.AddHead("b");
        stringList.AddHead("c");
        Console.WriteLine("\nВиведення пов'язаного списку складеного із рядків:\n" + stringList);
        Console.WriteLine("\nЗнаходження мінімального елементу пов'язаного списку складеного із рядків\n" + stringList.FindMin());
    }
}
