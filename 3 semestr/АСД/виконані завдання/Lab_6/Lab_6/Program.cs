using System;
using Lab_6;

namespace Lab_6
{
	public class Program
	{
		static public void Main()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			int temp = 0;
			while (true)
			{
				try
				{
					Console.WriteLine("Введіть кількість чисел у масиві");
					temp = int.Parse(Console.ReadLine());
					if (temp < 1)
					{
						throw new Exception("Неможливо створити масив");
					}
				}
				catch(Exception e)
				{
					Console.WriteLine(e.Message);
					Main();
				}
				int[] array = new int[temp];
				Random random = new Random();
				for (int i = 0; i < temp; i++)
				{
					array[i] = random.Next(8000);
				}
                Console.WriteLine("Створений масив:");
                foreach (int i in array)
				{
					Console.WriteLine(i);
				}
				BinaryInject.BinaryInjectionSort(array);
				Console.WriteLine("Відсортований масив:");
				foreach (int i in array)
				{
					Console.WriteLine(i);
				}
				Console.WriteLine("Продовжити? 1 - так");
				if(Console.ReadLine() != "1")
				{
					Environment.Exit(0);
				}
				Console.Clear();
			}
		}
	}
}
