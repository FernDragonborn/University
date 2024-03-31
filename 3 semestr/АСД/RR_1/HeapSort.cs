namespace RR_1;

public class HeapSort
{
    public static void Sort(int[] arr)
    {
        int n = arr.Length;

        // Build max-heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }

        for (int i = n - 1; i >= 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }

    public static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest == i) return;

        int swap = arr[i];
        arr[i] = arr[largest];
        arr[largest] = swap;

        Heapify(arr, n, largest);
    }

    public static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        if (n == 0)
        {
            Console.WriteLine("Масив пустий");
            return;
        }
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}

public class HeapSort<TKey, TValue> where TKey : IComparable<TKey>
{
    public static void Sort(KeyValuePair<TKey, TValue>[] arr)
    {
        int n = arr.Length;

        // Build max-heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }

        for (int i = n - 1; i >= 0; i--)
        {
            KeyValuePair<TKey, TValue> temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            Heapify(arr, i, 0);
        }
    }

    public static void Heapify(KeyValuePair<TKey, TValue>[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[left].Key.CompareTo(arr[largest].Key) > 0)
            largest = left;

        if (right < n && arr[right].Key.CompareTo(arr[largest].Key) > 0)
            largest = right;

        if (largest == i) return;

        KeyValuePair<TKey, TValue> swap = arr[i];
        arr[i] = arr[largest];
        arr[largest] = swap;

        Heapify(arr, n, largest);
    }

    public static void PrintArray(KeyValuePair<TKey, TValue>[] arr)
    {
        int n = arr.Length;
        if (n == 0)
        {
            Console.WriteLine("Масив пустий");
            return;
        }
        for (int i = 0; i < n; ++i)
            Console.Write($"({arr[i].Key}, {arr[i].Value}) ");
        Console.WriteLine();
    }
}
