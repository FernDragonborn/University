using System.Diagnostics;


namespace Lab_6
{
	class Program
	{
		public static void Main()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			MyStack myStack;
			myStack = new MyStack();
			Stack<int> stack = new Stack<int>();
			Console.WriteLine("20000 ітерацій");
			TickMeasurementAddingToMyStack(myStack, 20000);
			TickMeasurementPopingMyStack(myStack, 20000);
			TickMeasurementAddingToStack(stack, 20000);
			TickMeasurementPopingStack(stack, 20000);
			Console.WriteLine("40000 ітерацій");
			TickMeasurementAddingToMyStack(myStack, 40000);
			TickMeasurementPopingMyStack(myStack, 40000);
			TickMeasurementAddingToStack(stack, 40000);
			TickMeasurementPopingStack(stack, 40000);
			Console.WriteLine("60000 ітерацій");
			TickMeasurementAddingToMyStack(myStack, 60000);
			TickMeasurementPopingMyStack(myStack, 60000);
			TickMeasurementAddingToStack(stack, 60000);
			TickMeasurementPopingStack(stack, 60000);
			Console.WriteLine("80000 ітерацій");
			TickMeasurementAddingToMyStack(myStack, 80000);
			TickMeasurementPopingMyStack(myStack, 80000);
			TickMeasurementAddingToStack(stack, 80000);
			TickMeasurementPopingStack(stack, 80000);
			Console.WriteLine("100000 ітерацій");
			TickMeasurementAddingToMyStack(myStack, 100000);
			TickMeasurementPopingMyStack(myStack, 100000);
			TickMeasurementAddingToStack(stack, 100000);
			TickMeasurementPopingStack(stack, 100000);
			Console.WriteLine("120000 ітерацій");
			TickMeasurementAddingToMyStack(myStack, 120000);
			TickMeasurementPopingMyStack(myStack, 120000);
			TickMeasurementAddingToStack(stack, 120000);
			TickMeasurementPopingStack(stack, 120000);
		}
		public static void TickMeasurementAddingToMyStack(MyStack myStack, int n)
		{
			Console.WriteLine("Додавання у MyStack");
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int i = 0; i < n; i++)
			{
				myStack.Push(i);
			}
			Console.WriteLine(stopwatch.ElapsedTicks.ToString());
			stopwatch.Stop();
		}
		public static void TickMeasurementPopingMyStack(MyStack myStack, int n)
		{
			Console.WriteLine("Видалення з MyStack");
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int i = 0; i < n; i++)
			{
				myStack.Pop();
			}
			Console.WriteLine(stopwatch.ElapsedTicks.ToString());
			stopwatch.Stop();
		}
		public static void TickMeasurementAddingToStack(Stack<int> Stack, int n)
		{
			Console.WriteLine("Додавання у Stack<int>");
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int i = 0; i < n; i++)
			{
				Stack.Push(i);
			}
			Console.WriteLine(stopwatch.ElapsedTicks.ToString());
			stopwatch.Stop();
		}
		public static void TickMeasurementPopingStack(Stack<int> Stack, int n)
		{
			Console.WriteLine("Видалення з Stack<int>");
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int i = 0; i < n; i++)
			{
				Stack.Pop();
			}
			Console.WriteLine(stopwatch.ElapsedTicks.ToString());
			stopwatch.Stop();
		}
	}
}
