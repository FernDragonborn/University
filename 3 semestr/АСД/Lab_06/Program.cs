using System.Text;

namespace Lab_06;
public class Program
{
    public static void Main()
    {
        while (true)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);

            Random rand = new();

            Console.WriteLine("Введіть к-ть елементів масиву: ");
            uint lenght = 0;
            try
            {
                lenght = Convert.ToUInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Некоректний ввід довжини");
                Console.WriteLine("\n\nНатисніть будь-яку клавішу, щоб продовжити");
                Console.ReadKey();
                Console.Clear();
                continue;
            }

            int[] arr = new int[lenght];
            for (int i = 0; i < lenght; i++)
            {
                arr[i] = rand.Next(-100, 100);
            }

            Console.WriteLine("\nПоточний масив: ");
            HeapSort.PrintArray(arr);

            HeapSort.Sort(arr);

            Console.WriteLine("\nВідсортований масив: ");
            HeapSort.PrintArray(arr);

            Console.WriteLine("\n\nНатисніть будь-яку клавішу, щоб продовжити");
            Console.ReadKey();
            Console.Clear();
        }
    }

}

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

