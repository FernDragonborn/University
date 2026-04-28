using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Elem
    {
        public Elem _L;
        public  int _data;
        public int _id;
        public static int Count = 0;

        public Elem(int data)
        {
            _data = data;
            _id=++Count;
        }
    }
    public class MyStack
    {
        public Elem _Top;
        public void Push(int data)
        {
            Elem temporary = new Elem(data);
            if (_Top != null)
                temporary._L = _Top;
            _Top = temporary;
        }
        public void Pop()
        {
            if (_Top != null && _Top._L != null)
            {
                Elem temporary = new Elem(_Top._L._data);
                temporary = _Top._L;
                _Top = temporary;
                return;
            }
            else if (_Top != null && _Top._L == null)
            {
                _Top = null;
                return;
            }
        }
        public bool Empty()
        {
            if (_Top == null)
                return true;
            return false;
        }
        public override string ToString()
        {
            if (_Top != null)
            {
                int Result = int.MinValue;
                for (Elem el = _Top; el != null; el = el._L)
                {
                    if (Result < el._data)
                        Result = el._data;
                }
                return ("Найбільший елемент стеку - " + Result.ToString());
            }
            return ("Неможливо знайти найбільший елемент, стек пустий");
        }
        public void StackContaintment()
        {
            if (_Top != null)
            {
                string dataofstack = ""; int i = 0;
                for (Elem el = _Top; el != null; el = el._L, i++)
                {
                    dataofstack += el._data.ToString() + ", ";
                }
                return;
            }
        }
    }
}
