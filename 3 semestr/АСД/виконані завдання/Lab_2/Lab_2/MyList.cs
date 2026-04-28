namespace Lab_2;

public class Elem
{
    public Elem _l, _r;
    public double _data;
    public Elem(double data)
    {
        _data = data;
    }
}
public class MyQueue
{
    Elem _tail, _head;
    public void AddToQueue(double info)
    {
        Elem temp = new Elem(info);
        if (_tail != null)
        {
            temp._l = _tail;
            temp._r = _head;
            _head._l = temp;
            _tail._r = temp;
        }
        else
        {
            _head = temp._r = temp._l = temp;
        }
        _tail = temp;
    }
    public void DeleteFromQueue()
    {
        if (_tail != _head)
        {
            _head = _head._r;
            _tail._r = _head;
            _head._l = _tail;
        }
        else if (_head._r == _head)
        {
            MyQueue temp = new MyQueue();
            _head = _tail = temp._head = temp._tail;
        }
        else if (Empty())
        {
            throw new Exception("Черга пуста");
        }
    }
    public bool Empty()
    {
        if (_tail == null)
            return true;
        return false;
    }
    public string FirstElem()
    {
        if (!Empty())
        {
            return "(" + _head._l._data.ToString() + ")" + _head._data.ToString() + "(" + _head._r._data.ToString() + ")" + "; ";
        }
        else return "Чегра пуста";
    }
    public string QueueContaintement()
    {
        if (!Empty())
        {
            Elem temp = _head; string Result = "Додані елементи:"; int counter = 0;
            do
            {
                Result += "(" + temp._l._data.ToString() + ")" + temp._data.ToString() + "(" + temp._r._data.ToString() + ")" + "; ";
                temp = temp._r; counter++;
            }
            while (temp != _head);
            Result += "\nКількість елементів: " + counter;
            return Result;
        }
        return "Черга пуста";
    }
    public override string ToString()
    {
        if (!Empty())
        {
            return "Сума всіх елементів списку = " + Sum().ToString();
        }
        return "Черга пуста";
    }
    public double Sum()
    {
        Elem temp = _tail; double Result = 0;
        do
        {
            Result += temp._data;
            temp = temp._l;
        }
        while (temp != _tail);
        return Result;
    }
}