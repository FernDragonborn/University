using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_5
{
	public class UPCommunication
	{
		public Graph graph;
		public UPCommunication()
		{
			graph = new Graph();
		}
		public void UserOptions()
		{
			try
			{
				Console.WriteLine("Виберіть опцію:\n1 - Додати елемент" +
					"\n2 - Додати зв'язок\n3 - Видалити елемент" +
					"\n4 - Перевірити існування\n5 - Вивести граф" +
                    "\n6 - Записати у файл\n7 - Зчитати з файлу\n8 - Вихід");
				switch (Console.ReadLine())
				{
					case "1":
						Console.Clear();
						AddElement();
						break;
					case "2":
						Console.Clear();
						AddConnection();
						break;
					case "3":
						Console.Clear();
						RemoveElement();
						break;
					case "4":
						Console.Clear();
						Check();
						break;
					case "5":
						Console.Clear();
						Show();
						break;
                    case "6":
                        Console.Clear();
                        WriteTxt();
                        break;
                    case "7":
                        Console.Clear();
                        ReadTxt();
                        break;
                    case "8":
						Console.Clear();
						Environment.Exit(1);
						break;
					default: throw new Exception("Немає такої опції");
				}
			}
			catch (Exception ex)
			{
				ReturnToOptions(ex);
			}
		}
		public void AddElement()
		{
			try
			{
				Console.WriteLine("Введіть дані вершини");
				graph.AddElement(int.Parse(Console.ReadLine()));
				Console.WriteLine("Успішно додано вершину");
				ReturnToOptions();
			}
			catch (Exception ex)
			{
				ReturnToOptions(ex);
			}
		}
		public void AddConnection()
		{
			try
			{
				Console.WriteLine("Введіть вершину, яка входить у цю вершину");
				int pos = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть номер вершини");
                int connection = int.Parse(Console.ReadLine());
				if (pos == connection) throw new Exception("Не можлива операція");
                graph.AddConnection(connection, pos);
				Console.WriteLine("Успішно додано зв'язок");
				ReturnToOptions();
			}
			catch (Exception ex)
			{
				ReturnToOptions(ex);
			}
		}
		public void RemoveElement()
		{
			try
			{
				Console.WriteLine("Введіть номер вершини");
				int pos = int.Parse(Console.ReadLine());
				if (graph.RemoveElement(pos))
					Console.WriteLine("Видалено вершину");
				else Console.WriteLine("Не видалено вершину");
                ReturnToOptions() ;	
			}
			catch(Exception ex)
			{
				ReturnToOptions(ex);
			}
		}
		public void Check()
		{
			try
			{
				Console.WriteLine("Введіть номер вершини");
				int pos = int.Parse(Console.ReadLine());
				if(graph.Check(pos))
					Console.WriteLine("Вершина існує");
				else Console.WriteLine("Вершини не існує");
				ReturnToOptions();
			}
			catch (Exception ex)
			{
				ReturnToOptions(ex);
			}
		}
		public void WriteTxt()
		{
			try
			{
                Console.WriteLine("Вкажіть розташування файлу");
                string filepath = Console.ReadLine();
				StreamWriter streamWriter = new StreamWriter(filepath);
                streamWriter.Write(graph.ToString());
                streamWriter.Close();
                Console.WriteLine("Створено/Змінено документ");
                ReturnToOptions();
            }
			catch(Exception e)
			{
				ReturnToOptions(e);
			}
        }
		public void ReadTxt()
		{
			try
			{
                Console.WriteLine("Вкажіть розташування файлу");
				int count=graph.list.Count;
                using (StreamReader reader = new StreamReader(Console.ReadLine()))
                {
                    string[] temp = Regex.Split(reader.ReadToEnd(), @"(?<!\d)0(?!10)(?!\d)");
                    graph.AddElement(temp);
                }
				if (graph.list.Count == count) throw new Exception("Не зчитано жодного елемента");
                Console.WriteLine("Прочитано документ");
                ReturnToOptions();
            }
			catch(Exception ex)
			{
				ReturnToOptions(ex);
			}
		}
		public void Show()
		{
			Console.WriteLine(graph.Show());
			ReturnToOptions() ;
		}
		public void ReturnToOptions()
		{
			Console.WriteLine("\nНатисніть будь яку клавішу");
			Console.ReadLine();
			Console.Clear();
			UserOptions();
		}
		public void ReturnToOptions(Exception ex)
		{
			Console.WriteLine(ex.Message);
			Console.WriteLine("\nНатисніть будь яку клавішу");
			Console.ReadLine();
			Console.Clear();
			UserOptions();
		}
	}
}
