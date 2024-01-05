namespace Lab_02;

using System;

class Node
{
    public char Data;
    public Node Next;
    public Node Previous;

    public Node(char data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

class CircularLinkedList
{
    private Node head;

    public CircularLinkedList()
    {
        head = null;
    }

    public void Initialize()
    {
        head = null;
    }

    public void AddElement(char? data)
    {
        if (data is null) throw new InvalidOperationException();
        Node newNode = new Node((char)data);

        if (head == null)
        {
            head = newNode;
            head.Next = head;
            head.Previous = head;
        }
        else
        {
            Node lastNode = head.Previous;

            lastNode.Next = newNode;
            newNode.Previous = lastNode;
            newNode.Next = head;
            head.Previous = newNode;
        }
    }

    public void RemoveElement(char data)
    {
        if (head == null)
            return;

        Node current = head;

        do
        {
            if (current.Data == data)
            {
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;

                if (current == head)
                    head = current.Next;

                return;
            }

            current = current.Next;
        } while (current != head);
        throw new InvalidOperationException();
    }

    public char Peek()
    {
        if (head == null)
            throw new InvalidOperationException("The list is empty.");

        return head.Data;
    }

    public bool IsEmpty()
    {
        return head == null;
    }

    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Node current = head;

        do
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        } while (current != head);

        Console.WriteLine();
    }

    public int CountElements()
    {
        if (head == null)
            return 0;

        int count = 0;
        Node current = head;

        do
        {
            count++;
            current = current.Next;
        } while (current != head);

        return count;
    }

    public char FindMiddleElement()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Cannot find middle element in an empty list.");
        }

        Node current = head;

        int middle = CountElements() / 2;
        current = head;

        for (int i = 0; i < middle; i++)
        {
            current = current.Next;
        }

        return current.Data;
    }

}

class Program
{
    static void Main()
    {
        CircularLinkedList circularList = new CircularLinkedList();

        // Тест-кейс 1: Додавання
        circularList.Initialize();
        circularList.AddElement('A');
        circularList.AddElement('B');
        circularList.AddElement('C');
        Console.WriteLine("Test Case 1: After adding elements:");
        circularList.Display();

        // Тест-кейс 2: Додавання пустого значення
        try
        {
            circularList.AddElement(null); // Розкоментуйте цей рядок для демонстрації помилки
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Test Case 2: Error adding empty value: {ex.Message}");
        }

        // Тест-кейс 3: Видалення
        circularList.RemoveElement('B');
        Console.WriteLine("Test Case 3: After removing 'B':");
        circularList.Display();

        // Тест-кейс 4: Видалення неіснуючого елементу
        try
        {
            circularList.RemoveElement('X'); // Розкоментуйте цей рядок для демонстрації виводу повідомлення
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Test Case 4: Error removing non-existent element: {ex.Message}");
        }

        // Відновлення видалених елементів
        circularList.AddElement('B');

        // Тест-кейс 5: Перегляд першого елементу
        try
        {
            Console.WriteLine("Test Case 5: Peek: " + circularList.Peek());
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Test Case 5: Error peeking into an empty list: {ex.Message}");
        }

        // Тест-кейс 6: Перегляд першого елементу, коли він не існує
        try
        {
            circularList.Initialize(); // Розкоментуйте цей рядок для демонстрації виводу повідомлення
            Console.Write("Test Case 6: Peek: " + circularList.Peek() + "\nList elements: ");
            circularList.Display();
        }
        catch (InvalidOperationException ex)
        {
            Console.Write($"Test Case 6: Error peeking into an empty list: {ex.Message}\nList elements: ");
            circularList.Display();
        }

        // Відновлення видалених елементів
        circularList.AddElement('A');
        circularList.AddElement('C');

        // Тест-кейс 7: Перевірка списку на порожність
        Console.Write("Test Case 7: Is the list empty?: " + circularList.IsEmpty() + "\nList elements: ");
        circularList.Display();
        // Тест-кейс 8: Виведення структури на екран
        Console.WriteLine("Test Case 8: Display:");
        circularList.Display();

        // Тест-кейс 9: Виведення структури за відсутності елементів
        try
        {
            circularList.Initialize(); // Розкоментуйте цей рядок для демонстрації виводу повідомлення
            Console.WriteLine("Test Case 9: Display:");
            circularList.Display();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Test Case 9: Error displaying an empty list: {ex.Message}");
        }

        // Відновлення видалених елементів
        circularList.AddElement('A');
        circularList.AddElement('B');
        circularList.AddElement('C');

        // Тест-кейс 10: Підрахунок числа елементів
        Console.Write("Test Case 10: Number of elements in the list: " + circularList.CountElements() + "\nList elements: ");
        circularList.Display();

        // Тест-кейс 11: Підрахунок числа елементів за їх відсутності
        circularList.Initialize(); // Розкоментуйте цей рядок для демонстрації виводу повідомлення
        Console.Write("Test Case 11: Number of elements in the list: " + circularList.CountElements() + "\nList elements: ");
        circularList.Display();

        // Відновлення видалених елементів
        circularList.AddElement('A');
        circularList.AddElement('B');
        circularList.AddElement('C');

        // Тест-кейс 12: Пошук мерединного значення
        Console.Write("Test Case 12: Middle element: " + circularList.FindMiddleElement() + "\nList elements: ");
        circularList.Display();

        // Тест-кейс 13: Пошук серединного значення за відстуності елементів
        try
        {
            circularList.Initialize(); // Розкоментуйте цей рядок для демонстрації виводу повідомлення
            Console.WriteLine("Test Case 13: Middle element: " + circularList.FindMiddleElement());
        }
        catch (InvalidOperationException ex)
        {
            Console.Write($"Test Case 13: {ex.Message}\nList elements: ");
            circularList.Display();
        }

    }
}
