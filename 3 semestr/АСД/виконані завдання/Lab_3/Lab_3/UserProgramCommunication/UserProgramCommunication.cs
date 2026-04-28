using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3.BackEnd;

namespace Lab_3
{
    public class UserProgramCommunication
    {
        TopStructure mystructure;
        public void InitialiseList()
        {
            Console.WriteLine("Натисніть будь яку клавішу що б створити структуру");
            Console.ReadKey();
            mystructure = new TopStructure();
            Console.WriteLine("\nСтворено чергу!");
            ReturnToOptions();
        }
        public void UserOptions()
        {
            try
            {
                Console.WriteLine("Виберіть опцію:\n1 - Додати елемент" +
                    "\n2 - Видалити елемент\n3 - Перевірити список\n4 - Переглянути перший елемент\n"+
                    "5 - Переглянути структуру\n6 - Вихід");
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
                        FirstElement();
                        break;
                    case "5":
                        Console.Clear();
                        ShowStructure();
                        break;
                    case "6":
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
                Console.WriteLine("1 - Додати масив до черги, 2 - Додати елемент до масиву");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Вводьте елементи через пробіл(string)");
                        mystructure.AddElement(Console.ReadLine());
                        Console.WriteLine("Додано масив та введені елементи");
                        ReturnToOptions();
                        break;
                    case "2":
                        Console.WriteLine("Введіть дані через пробіл(string)");
                        string tempdata = Console.ReadLine();
                        mystructure.AddElement(tempdata, 1);
                        Console.WriteLine("Додано до масиву");
                        ReturnToOptions();
                        break;
                    default: throw new Exception("Немає такої опції");
                }
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
                Console.WriteLine("1 - Видалити масив з черги, 2 - Видалити елемент з масиву");
                switch (Console.ReadLine())
                {
                    case "1":
                        mystructure.DeleteFromQueue();
                        Console.WriteLine("Видалено з черги");
                        ReturnToOptions();
                        break;
                    case "2":
                        Console.WriteLine("Введіть дані (string)");
                        string tempdata = Console.ReadLine();
                        mystructure.DeleteFromQueue(tempdata);
                        Console.WriteLine("Видалено з масиву");
                        ReturnToOptions();
                        break;
                    default: throw new Exception("Немає такої опції");
                }
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
                Console.WriteLine("1 - Перевірити чергу, 2 - Перевірити масив");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (mystructure.Empty())
                            Console.WriteLine("Черга пуста");
                        else Console.WriteLine("Черга не пуста");
                        ReturnToOptions();
                        break;
                    case "2":
                        if (mystructure.Empty(1))
                             Console.WriteLine("Масив пустий");
                        else Console.WriteLine("Масив не пустий");
                        ReturnToOptions();
                        break;
                    default: throw new Exception("Немає такої опції");
                }
            }
            catch (Exception ex)
            {
                ReturnToOptions(ex);
            }
        }
        public void FirstElement()
        {
            try
            {
                Console.WriteLine("1 - Перший елемент чегри, 2 - Перший елемент масиву");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine(mystructure.Peek());
                        ReturnToOptions();
                        break;
                    case "2":
                        Console.WriteLine(mystructure.Peek(1));
                        ReturnToOptions();
                        break;
                    default: throw new Exception("Немає такої опції");
                }
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
                Console.WriteLine(mystructure.StructureShow());
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
            Console.WriteLine("\n" + ex.ToString());
            Console.WriteLine("\nНатисніть будь яку клавішу");
            Console.ReadLine();
            Console.Clear();
            UserOptions();
        }
    }
}
