using System.Collections;

namespace Lab_03;

public class ArrayListOfMyQueues
{
    private readonly ArrayList _arrayList = new();

    public int Count => _arrayList.Count;

    public bool IsEmpty => Count == 0;

    public void Add(MyQueue queue)
    {
        if (queue is null) throw new ArgumentNullException(nameof(queue));
        _arrayList.Add(queue);
    }

    public MyQueue? Peek() => (MyQueue?)_arrayList[0];

    public bool RemoveAt(int i)
    {
        try
        {
            _arrayList.RemoveAt(i);
        }
        catch
        {
            return false;
        }
        return true;
    }

    public void WriteToConsole()
    {
        if (IsEmpty) Console.WriteLine("ArrayList is empty"); ;
        foreach (MyQueue queue in _arrayList)
        {
            Console.WriteLine(queue.ToString());
        }
    }
}

public class MyQueue
{
    private readonly Queue<Element> _queue = new();
    public int Id;

    public MyQueue(int id)
    {
        Id = id;
    }

    public bool IsEmpty => _queue.Count == 0;

    public void Enqueue(Element element) => _queue.Enqueue(element);

    public Element Dequeue() => _queue.Dequeue();

    public Element Peek() => _queue.Peek();

    public void WriteToConsole()
    {
        if (IsEmpty) Console.WriteLine("Queue is empty"); ;
        foreach (Element element in _queue)
        {
            Console.WriteLine($"{element.TopIndex} - {element.Id} contains: \"{element.Data}\"");
        }
    }

    public override string ToString()
    {
        string result = $"Номер масиву: {Id}\n";
        int i = 0;
        foreach (Element element in _queue)
        {
            result += $"Індекс елементу: {i}, дані: {element.Data}\n";
            i++;
        }
        return result;
    }
}

public struct Element
{
    public Element(string data, int topIndex, int index)
    {
        Data = data;
        TopIndex = topIndex;
        Id = index;
    }

    public string Data { get; set; }

    public int TopIndex { get; set; }

    public int Id { get; set; }

    public override string ToString()
    {
        return $"{TopIndex} {Id} {Data}";
    }
}

class Program
{
    public static void Main()
    {

    }
}