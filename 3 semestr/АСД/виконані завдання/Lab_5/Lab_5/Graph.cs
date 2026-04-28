using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
	public class Graph
	{
		public LinkedList<ElGraph> list;
		public Graph()
		{
			list = new LinkedList<ElGraph>();
		}
		public void AddElement(string[] lines)
		{
			int startpoint=list.Count+1;
			foreach (string line in lines)
			{
                int temp=list.Count+1; 
                AddElement(temp);
            }
			foreach (string line in lines)
			{
                string[] split = line.Split(' ');
				for (int i = 0; i < split.Length; i++)
				{
					int temp;
					if (split[i]==""||!int.TryParse(split[i], out temp))
						continue;
					if(!CheckConnection(startpoint,temp))
						AddConnection(startpoint, temp);
				}
				startpoint++;
            }
			if (list.Last()._L.Count==1)
				RemoveElement(list.Last().info);
		}
		public void AddElement(int info)
		{
			if (Check(info)) throw new Exception("Елемент уже є у графі");
			list.AddLast(new ElGraph(info));
		}
		public void AddConnection(int pos, int info)
        {
			if (pos==info) return;
            ElGraph temp = Find(pos);
            if (temp == null||Find(info)==null)
            {
                throw new Exception("Немає такого елемента");
            }
            temp.AddConnection(Find(info));
            temp = Find(info);
            temp.AddConnection(Find(pos));
        }
        public ElGraph Find(int info)
		{
			foreach (var el in list)
			{
				if (el.info == info)
					return el;
			}
			return null;
		}
		public bool CheckConnection(int info, int pos)
		{
			if ((Find(info) != null && Find(info).FindConnection(pos)) || (Find(pos) != null && Find(pos).FindConnection(info)))
				return true;
			return false;
		}
		public bool Check(int info)
		{
			foreach (var el in list)
			{
				if (el.info == info)
					return true;
			}
			return false;
		}
		public bool RemoveElement(int info)
		{
			if(Find(info) != null)
			{
				list.Remove(Find(info));
				ElGraph.Count--;
				foreach (var el in list)
				{
					el.RemoveConnection(info);
					ElGraph.ConnectionCount--;
				}
				return true;
			}
			return false;
		}
		public string Show()
		{
			string result="";
			foreach(ElGraph el in list) 
			{
				result += el.Show()+"\n";
			}
			return result;
		}
        public override string ToString()
        {
            string result = "";
            foreach (ElGraph el in list)
            {
                result += el.ToString() + " ";
            }
            return result;
        }
    }
	public class ElGraph
	{
		public int info;
		public static int Count = 0;
		public static int ConnectionCount = 0;
		public List<ElGraph?> _L;
		public ElGraph(int info)
		{
			if (Count > 20)
				throw new Exception("Занадто багато елементів");
			_L = new List<ElGraph?>();
			this.info=info;
			Count++;
			_L.Add(null);
		}
		public void AddConnection(ElGraph elGraph)
		{
			if (ConnectionCount > 50)
				throw new Exception("Занадто багато зв'язків");
			_L.Insert(_L.Count-1, elGraph);
			ConnectionCount++;

		}
		public bool FindConnection(int info)
		{
			return _L.Find(x => x != null && x.info == info)!=null;

        }
		public bool RemoveConnection(int info)
		{
			return _L.Remove(_L.Find(x => x!=null&&x.info==info));
		}
		public string Show()
		{
			string result = $"{info} <- ";
			foreach(ElGraph elGraph in _L)
			{
                if (elGraph == null)
                    break;
                result += $"{elGraph.info} ";
            }
			return result;
		}
        public override string ToString()
        {
			string result="";
			foreach(ElGraph elGraph in _L)
			{
                result += $"{elGraph.info} ";
            }
			result += "0";
            return result;
        }
    }
}
