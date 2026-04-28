using System.Diagnostics;
using System.Text;

namespace Lab_6
{
	class Program
	{
		public static void Main()
		{
			Console.OutputEncoding=UTF8Encoding.UTF8;
            Console.WriteLine("20000 ітерацій");
			RandomElements(20000);
			SortedElements(20000);
			SortedReverseElements(20000);
			Console.WriteLine("40000 ітерацій");
			RandomElements(40000);
			SortedElements(40000);
			SortedReverseElements(40000);
			Console.WriteLine("60000 ітерацій");
			RandomElements(60000);
			SortedElements(60000);
			SortedReverseElements(60000);
			Console.WriteLine("80000 ітерацій");
			RandomElements(80000);
			SortedElements(80000);
			SortedReverseElements(80000);
			Console.WriteLine("100000 ітерацій");
			RandomElements(100000);
			SortedElements(100000);
			SortedReverseElements(100000);
			Console.WriteLine("120000 ітерацій");
			RandomElements(120000);
			SortedElements(120000);
			SortedReverseElements(120000);
		}
		public static void RandomElements(int n)
		{
            Console.WriteLine("Випадковий порядок");
            Stopwatch sw = new Stopwatch();
			int[] array = new int[n];
			Random random = new Random();
			for (int i = 0; i < n; i++)
			{
				array[i] = random.Next(n+1);
			}
			sw.Start();
			BinaryInject.BinaryInjectionSort(array);
			Console.WriteLine(sw.ElapsedTicks);
			sw.Stop();
		}
		public static void SortedElements(int n)
		{
			Console.WriteLine("Сортований порядок");
			Stopwatch sw = new Stopwatch();
			int[] array = new int[n];
			Random random = new Random();
			for (int i = 0; i < n; i++)
			{
				array[i] = i;
			}
			sw.Start();
			BinaryInject.BinaryInjectionSort(array);
			Console.WriteLine(sw.ElapsedTicks);
			sw.Stop();
		}
		public static void SortedReverseElements(int n)
		{
			Console.WriteLine("Сортований зворотній порядок");
			Stopwatch sw = new Stopwatch();
			int[] array = new int[n];
			Random random = new Random();
			for (int i = n-1; i >=0; i--)
			{
				array[i] = i;
			}
			sw.Start();
			BinaryInject.BinaryInjectionSort(array);
			Console.WriteLine(sw.ElapsedTicks);
			sw.Stop();
		}
	}
}