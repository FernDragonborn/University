using Lab_03;

public class ArrayListOfMyQueuesTests
{
    [Fact]
    public void ArrayList_AddQueue_Success()
    {
        // Arrange
        ArrayListOfMyQueues arrayList = new ArrayListOfMyQueues();
        MyQueue queue = new MyQueue(0);

        // Act
        arrayList.Add(queue);

        // Assert
        Assert.Equal(1, arrayList.Count);
    }

    [Fact]
    public void ArrayList_Add_NullQueue_ArgumentNullException()
    {
        // Arrange
        ArrayListOfMyQueues arrayList = new ArrayListOfMyQueues();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => arrayList.Add(null));
    }

    [Fact]
    public void ArrayList_RemoveAt_Success()
    {
        // Arrange
        ArrayListOfMyQueues arrayList = new ArrayListOfMyQueues();
        MyQueue queue = new MyQueue(0);
        arrayList.Add(queue);

        // Act
        bool result = arrayList.RemoveAt(0);

        // Assert
        Assert.True(result);
        Assert.Equal(0, arrayList.Count);
    }

    [Fact]
    public void ArrayList_RemoveAt_InvalidIndex_ReturnsFalse()
    {
        // Arrange
        ArrayListOfMyQueues arrayList = new ArrayListOfMyQueues();
        MyQueue myQueue = new MyQueue(0);
        arrayList.Add(myQueue);

        // Act
        bool result = arrayList.RemoveAt(1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ArrayList_Peek_Success()
    {
        // Arrange
        ArrayListOfMyQueues arrayList = new ArrayListOfMyQueues();
        MyQueue queue = new MyQueue(0);
        arrayList.Add(queue);

        // Act
        MyQueue result = arrayList.Peek();

        // Assert
        Assert.Equal(queue, result);
    }

    [Fact]
    public void ArrayList_Peek_InvalidIndex_ArgumentOutOfRangeException()
    {
        // Arrange
        ArrayListOfMyQueues arrayList = new ArrayListOfMyQueues();

        // Act & Assser
        Assert.Throws<ArgumentOutOfRangeException>(arrayList.Peek);
    }

    [Fact]
    public void ArrayList_ConsoleOutput()
    {
        // Arrange
        ArrayListOfMyQueues arrayList = new ArrayListOfMyQueues();

        MyQueue queue1 = new MyQueue(0);
        queue1.Enqueue(new Element("Data1", 1, 0));
        arrayList.Add(queue1);

        MyQueue queue2 = new MyQueue(1);
        queue2.Enqueue(new Element("Data2", 2, 0));
        queue2.Enqueue(new Element("Data3", 2, 1));
        arrayList.Add(queue2);

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        arrayList.WriteToConsole();
        string actualOutput = sw.ToString().Trim();

        // Assert
        string expectedOutput = "Номер масиву: 0\nІндекс елементу: 0, дані: Data1\n\r\nНомер масиву: 1\nІндекс елементу: 0, дані: Data2\nІндекс елементу: 1, дані: Data3";

        Assert.Equal(expectedOutput, actualOutput);
    }
}

public class MuQueueTests
{
    [Fact]
    public void MyQueue_Enqueue_Success()
    {
        // Arrange
        MyQueue queue = new MyQueue(0);
        Element element = new Element("Test", 1, 0);

        // Act
        queue.Enqueue(element);

        // Assert
        Assert.Equal(1, queue.Peek().TopIndex);
    }

    [Fact]
    public void MyQueue_Dequeue_Success()
    {
        // Arrange
        MyQueue queue = new MyQueue(0);
        Element element = new Element("Test", 1, 0);
        queue.Enqueue(element);

        // Act
        Element result = queue.Dequeue();

        // Assert
        Assert.Equal(element, result);
        Assert.True(queue.IsEmpty);
    }

    [Fact]
    public void MyQueue_Peek_Success()
    {
        // Arrange
        MyQueue queue = new MyQueue(0);
        Element element = new Element("Test", 1, 0);
        queue.Enqueue(element);

        // Act
        Element result = queue.Peek();

        // Assert
        Assert.Equal(element, result);
        Assert.False(queue.IsEmpty);
    }

    [Fact]
    public void MyQueue_Peek_InvalidIndex_ArgumentOutOfRangeException()
    {
        // Arrange
        MyQueue queue = new MyQueue(0);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
        Assert.True(queue.IsEmpty);
    }

    [Fact]
    public void MyQueue_WriteToConsole()
    {
        // Arrange
        MyQueue myQueue = new MyQueue(0);
        myQueue.Enqueue(new Element("TestData", 1, 0));

        using StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        myQueue.WriteToConsole();
        string actualOutput = sw.ToString().Trim();

        // Assert
        string expectedOutput = "1 - 0 contains: \"TestData\"";

        Assert.Equal(expectedOutput, actualOutput);
    }
}

public class ElementTests
{
    [Fact]
    public void Element_ToString()
    {
        // Arrange
        Element element = new Element("Test", 1, 0);

        // Act
        string result = element.ToString();

        // Assert
        Assert.Equal("1 0 Test", result);
    }
}
