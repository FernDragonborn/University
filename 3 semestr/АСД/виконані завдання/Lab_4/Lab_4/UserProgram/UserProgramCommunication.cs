using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4.BackEnd;

namespace Lab_4
{
    public class UserProgramComm
    {
        Tree tree;
        public void InitialiseList()
        {
            try
            {
				Console.WriteLine("Введіть ім'я першого предка");
				tree = new Tree(Console.ReadLine());
				Console.WriteLine("Створено дерево!");
				ReturnToOptions();
			}
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                InitialiseList();
            }
        }
        public void UserOptions()
        {
            try
            {
                Console.WriteLine("Виберіть опцію:\n1 - Додати елемент" +
                    "\n2 - Видалити елемент\n3 - Знайти гілку\n"+
                    "4 - Переглянути структуру\n5 - Вихід");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        AddElement();
                        break;
                    case "2":
                        Console.Clear();
                        RemoveElement();
                        break;
                    case "3":
                        Console.Clear();
                        CheckQueue();
                        break;
                    case "4":
                        Console.Clear();
                        ShowStructure();
                        break;
                    case "5":
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
                Console.WriteLine("Введіть ім'я предка");
                ElementOfTree temp = tree.Find(Console.ReadLine());
                if (temp != null)
                {
                    Console.WriteLine("Введіть ім'я нащадка");
                    string name=Console.ReadLine();
                    try
                    {
                        var t = new ElementOfTree(name);
						Console.WriteLine("Введіть сторону(L, R)");
                        string symb = Console.ReadLine();
						tree.Add(temp, name, symb);
						Console.WriteLine("Додано нащадка");
						ReturnToOptions();
					}
                    catch (Exception ex)
                    {
                        ReturnToOptions(ex);
                    }
				}
                throw new Exception("Немає такого предка");
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
                Console.WriteLine("Введіть назву");
                string temp=Console.ReadLine();
                if (temp == tree.root.Name)
                {
                    throw new Exception("Не можна видалити корінь");
                }
                if (tree.Delete(temp))
                {
                    Console.WriteLine(tree.SeeTree(tree.root));
                    ReturnToOptions() ;
                }
                throw new Exception("Не видалено жодної гілки");
            }
            catch (Exception ex)
            {
                ReturnToOptions(ex);
            }
        }
        public void CheckQueue()
        {
            try
            {
                Console.WriteLine("Введіть ім'я нащадка");
                string temp=Console.ReadLine();
                if(tree.Exists(temp))
                {
                    Console.WriteLine("Такий нащадок існує");
                    ReturnToOptions();
                }
				Console.WriteLine("Такого нащадка не існує");
				ReturnToOptions();
			}
            catch (Exception ex)
            {
                ReturnToOptions(ex);
            }
        }
        public void ShowStructure()
        {
            try
            {
                Console.WriteLine(tree.SeeTree(tree.root));
                ReturnToOptions();
            }
            catch (Exception ex)
            {
                ReturnToOptions(ex);
            }
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
