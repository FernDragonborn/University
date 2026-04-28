using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_3.BackEnd
{
    public class TopStructure
    {
        public static Queue<BottomStructure> structureBase = new Queue<BottomStructure>();
        public bool Empty()
        {
            return structureBase.Count == 0;
        }
        public bool Empty(int i)
        {
            return structureBase.Peek().Empty();
        }
        public void AddElement(string data)
        {
            string[] temp = data.Split(' ');
            BottomStructure temporarystruct = new BottomStructure();
            foreach(string d in temp)
            {
                if (d=="")
                {
                    continue;
                }
                temporarystruct.arrayList.Add(new Element(d));
            }
            if (!temporarystruct.Empty())
            {
                structureBase.Enqueue(temporarystruct);
                return;
            }
            throw new Exception("Не додано жодного елементу");
        }
        public void AddElement(string data, int i)
        {
            string[] temp = data.Split(' ');
            int countbefore = structureBase.Peek().arrayList.Count;
            foreach (string d in temp)
            {
                if (d == "")
                {
                    continue;
                }
                structureBase.Peek().arrayList.Add(new Element(d));
            }
            if (structureBase.Peek().arrayList.Count == countbefore)
                throw new Exception("Не додано жодного елементу");
        }
        public void DeleteFromQueue()
        {
            if (Empty())
                throw new Exception("Пуста черга");
            structureBase.Dequeue();
        }
        public void DeleteFromQueue(string data)
        {
            if (structureBase.Peek().Empty())
                throw new Exception("Список пустий");
            bool check=false;
            for(int i=0;  i<structureBase.Peek().arrayList.Count; i++)
            {
                Element elem = structureBase.Peek().arrayList[i] as Element;
                if (data==elem.Data)
                {
                    structureBase.Peek().arrayList.RemoveAt(i);
                    check = true;
                    i--;
                }     
            }
            if (!check) throw new Exception("Немає такого елементу");
        }
        public string Peek()
        {
            if (!Empty()&&!Empty(1))
            {
                string Result="";
                Result += structureBase.Peek().ToString() + " \n";
                return Result;
            }
            throw new Exception("Неможливо виконати операцію"); 
        }
        public string Peek(int i)
        {
            if (Empty())
                throw new Exception("Немає такого списку");
            if (Empty(i))
                throw new Exception("Список пустий");
            return structureBase.Peek().arrayList[0].ToString();
        }
        public string StructureShow()
        {
            if (Empty()) throw new Exception("Черга пуста");
            string Result = "Вміст структури:\n";
            foreach(BottomStructure bottomStructure in structureBase)
            {
                if (bottomStructure.Empty())
                    continue;
                Result += bottomStructure.ToString()+"\n" ;
            }
            if (Result == "Вміст структури:\n")
                Result="Усі списки пусті";
            return Result;
        }
    }
    public class BottomStructure
    {
        public ArrayList arrayList=new ArrayList();
        public int Id;
        public static int Count = 0;

        public BottomStructure()
        {
            Id = Count;
            Count++;
        }
        public bool Empty()
        {
            return arrayList.Count == 0;
        }
        public string ToString()
        {
            string Result = $"Номер масиву: {Id}\n";
            foreach(Element el in arrayList)
            {
                Result+= el.ToString() ;
            }
            return Result;
        }
    }

    public class Element
    {
        public static int ElementCount { get; set; } = 0;
        public int ElementIndex { get; } = ElementCount;
        public string Data { get; set; }
        public Element(string data) 
        {
            ++ElementCount;
            Data = data;
        }
        public override string ToString()
        {
            return $"Індекс елементу: {ElementIndex}, введені дані: {Data}\n";
        }
    }
}
