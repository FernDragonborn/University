namespace Module
{
    internal class Program
    {
        static void Main()
        {
            var arr = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                var rand = new Random();
                arr.Add(rand.Next(-10, 10));
            }
            foreach (int num in arr) Console.Write($" {num}");
            Console.WriteLine();
            int a = 0;
            minNotDouble(arr, out a);
            Console.WriteLine(a);
        }
        static void minNotDouble(List<int> arr, out int minNotDouble)
        {
            minNotDouble = arr[0];
            foreach (int num in arr)
            {
                if (Math.Abs(num % 2) == 1 && num < minNotDouble)
                {
                    minNotDouble = num;
                }
            }
        }
    }
}