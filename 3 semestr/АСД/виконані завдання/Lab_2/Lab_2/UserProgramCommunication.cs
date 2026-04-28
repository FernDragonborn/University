namespace Lab_2;

internal class UserProgramCommunication
{
    MyQueue myQueue;
    public void InitialiseList()
    {
        Console.WriteLine("Натисніть будь яку клавішу що б створити чергу");
        Console.ReadKey();
        myQueue = new MyQueue();
        Console.WriteLine("\nСтворено чергу!");
        ReturnToOptions();
    }
    public void UserOptions()
    {
        try
        {
            Console.WriteLine("Виберіть опцію:\n1 - Додати елемент" +
                "\n2 - Видалити елемент\n3 - Перевірити список\n4 - Переглянути елементи списку\n5 - Сума елементів" +
                "\n6 - Переглянути перший елемент у черзі\n7 - Вихід");
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
                    LastElement();
                    break;
                case "5":
                    Console.Clear();
                    ElementSum();
                    break;
                case "6":
                    Console.Clear();
                    LastAdded();
                    break;
                case "7":
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
    public void AddElement()
    {
        try
        {
            Console.WriteLine("Введіть значення елемента");
            double temp = double.Parse(Console.ReadLine());
            myQueue.AddToQueue(temp);
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
            if (!myQueue.Empty())
            {
                myQueue.DeleteFromQueue();
                Console.WriteLine("Видалено останній доданий елемент");
                ReturnToOptions();
            }
            throw new Exception("Пустий список");
        }
        catch (Exception ex)
        {
            ReturnToOptions(ex);
        }
    }
    public void CheckQueue()
    {
        if (myQueue.Empty())
        {
            Console.WriteLine("Черга пуста");
            ReturnToOptions();
        }
        Console.WriteLine("Черга не пуста");
        ReturnToOptions();
    }
    public void LastElement()
    {
        Console.WriteLine(myQueue.QueueContaintement());
        ReturnToOptions();
    }
    public void ElementSum()
    {
        Console.WriteLine(myQueue.ToString());
        ReturnToOptions();
    }
    public void LastAdded()
    {
        Console.WriteLine(myQueue.FirstElem());
        ReturnToOptions();
    }
}
