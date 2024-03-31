using RR_1;
using System.Collections;
using System.Diagnostics;
using System.Text;

#region configuration
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Console.InputEncoding = System.Text.Encoding.GetEncoding(1251);
Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);
#endregion

int[] iterationsCount = { 2000000, 4000000, 6000000, 8000000, 10000000, 12000000 };
MyLinkedList<int> myLinkedList = new();
LinkedList<int> genericLinkedList = new();
Stack embededLinkedList = new();

Console.WriteLine("Зв'язаний список:");
foreach (var count in iterationsCount)
{
    Console.WriteLine($"\n------------------------------------------\n{count} ітерацій");
    TickMeasurement_AddHead_MyLinkedList(myLinkedList, count);
    TickMeasurement_RemoveFirst_MyLinkedList(myLinkedList, count);
    GcClear();

    TickMeasurement_AddHead_GenericLinkedList(genericLinkedList, count);
    TickMeasurement_RemoveFirst_GenericLinkedList(genericLinkedList, count);
    GcClear();

    TickMeasurement_Push_Stack(embededLinkedList, count);
    TickMeasurement_Pop_Stack(embededLinkedList, count);
    GcClear();
}

Random rand = new();
Console.WriteLine("\n\nПірамідальне сортування:\n");


foreach (var count in iterationsCount)
{
    var arrKeyValue = new KeyValuePair<int, int>[count];
    Console.WriteLine($"\n------------------------------------------\n{count} ітерацій");
    for (int i = 0; i < arrKeyValue.Length; i++)
    {
        arrKeyValue[i] = new KeyValuePair<int, int>(rand.Next(0, 100), i);
    }
    Console.Write("Unsorted array:\t");
    TickMeasurment_HeapSort(arrKeyValue);
    GcClear();

    for (int i = 0; i < arrKeyValue.Length; i++)
    {
        arrKeyValue[i] = new KeyValuePair<int, int>(i, i);
    }
    Console.Write("Sorted array:\t\t");
    TickMeasurment_HeapSort(arrKeyValue);
    GcClear();


    for (int i = arrKeyValue.Length; i == 0; i--)
    {
        arrKeyValue[i] = new KeyValuePair<int, int>(i, i);
    }
    Console.Write("Ascending array:\t");
    TickMeasurment_HeapSort(arrKeyValue);
    GcClear();
}


static void GcClear()
{
    Console.WriteLine("Before collection:\t{0:N0}", GC.GetTotalMemory(false));
    Console.WriteLine("0 gen: " + GC.CollectionCount(0) +
                      "  |  1 gen: " + GC.CollectionCount(1) +
                      "  |  2 gen: " + GC.CollectionCount(2) +
                      "  |  3 gen: " + GC.CollectionCount(3));
    GC.Collect();
    Console.WriteLine();
}

#region MyLinkedList Methods
static void TickMeasurement_AddHead_MyLinkedList(MyLinkedList<int> myLinkedList, int n)
{
    Console.Write("Add to MyLinkedList<int>:\t");
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < n; i++)
    {
        myLinkedList.AddHead(i);
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedTicks.ToString("#,##0"));
}

static void TickMeasurement_RemoveFirst_MyLinkedList(MyLinkedList<int> myLinkedList, int n)
{
    Console.Write("Remove from MyLinkedList<int>:\t");
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < n; i++)
    {
        myLinkedList.TryRemoveHead();
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedTicks.ToString("#,##0"));
}

static void TickMeasurement_AddHead_GenericLinkedList(LinkedList<int> linkedList, int n)
{
    Console.Write("Add to LinkedList<int>: \t");
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < n; i++)
    {
        linkedList.AddFirst(i);
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedTicks.ToString("#,##0"));
}

static void TickMeasurement_RemoveFirst_GenericLinkedList(LinkedList<int> linkedList, int n)
{
    Console.Write("Remove from LinkedList<int>:\t");
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < n; i++)
    {
        linkedList.RemoveFirst();
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedTicks.ToString("#,##0"));
}

static void TickMeasurement_Push_Stack(Stack stack, int n)
{
    Console.Write("Add to Stack:\t\t\t");
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < n; i++)
    {
        stack.Push(i);
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedTicks.ToString("#,##0"));
}

static void TickMeasurement_Pop_Stack(Stack stack, int n)
{
    Console.Write("Remove from Stack:\t\t");
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < n; i++)
    {
        stack.Pop();
    }
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedTicks.ToString("#,##0"));
}

#endregion

#region HeapSort Methods

void TickMeasurment_HeapSort(KeyValuePair<int, int>[] arr)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    HeapSort<int, int>.Sort(arr);
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedTicks.ToString("#,##0"));
}


#endregion