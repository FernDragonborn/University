using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_4.BackEnd
{
	public class Tree
	{
		public ElementOfTree root;//корінь
		public Tree(string name)//створення дерева з коренем
		{
			Add(name);
		}	
		public void Add(ElementOfTree elementOfTree, string name, string pos)//додавання гілки
		{
			ElementOfTree newel = new(name);
			switch (pos)
			{
				case "L":
					if (elementOfTree.left == null)
					{
						elementOfTree.left = newel;
						break;
					}
					throw new Exception("Тут уже хтось є");
				case "R":
					if (elementOfTree.right == null)
					{
						elementOfTree.right = newel;
						break;
					}
					throw new Exception("Тут уже хтось є");
				default: throw new Exception("Немає такої опції");
			}
		}
		private void Add(string name)//додавання кореня дерева
		{
			root = new(name);
		}
		public bool Exists(string name)//перевірка на існування гілки
		{
			ElementOfTree temp = Find(name);
			if (temp!= null) return true;
			return false;
		}
		public ElementOfTree Find(string name)//пошук гілки
		{
			try
			{
				Queue<ElementOfTree> queue = new Queue<ElementOfTree>();
				queue.Enqueue(root);
				ElementOfTree V = queue.Dequeue();
				if (V.Name == name) return V;
				while (V.Name != name)
				{
					if (V.left != null)
					{
						if (V.left.Name == name)
							return V.left;
						queue.Enqueue(V.left);
					}
					if (V.right != null)
					{
						if (V.right.Name == name)
							return V.right;
						queue.Enqueue(V.right);
					}
					V = queue.Dequeue();
				}
				return null;
			}
			catch
			{
				return null;
			}
		}
		public ElementOfTree Find(ElementOfTree tryingtofind, ElementOfTree V)//Пошук батьківської гілки
		{
			if (V != null)
			{
				if (V.left == tryingtofind||V.right==tryingtofind) return V;
				ElementOfTree temp = Find(tryingtofind, V.left);
				if (temp != null) return temp;
				return temp = Find(tryingtofind, V.right);
			}
			return null;
		}
		public bool Delete(string name)//Видалення гілки
		{
			ElementOfTree tempchild= Find(name);
			if (tempchild != null)
			{
				ElementOfTree? tempfather = Find(tempchild, root);
				if (tempfather.left!=null&& tempfather.left.Equals(tempchild))
				{
					tempfather.left = null;
				}
				if ((tempfather.right != null && tempfather.right.Equals(tempchild)))
				{
					tempfather.right = null;
				}
				return true;
			}
			return false;
		}
		public string SeeTree(ElementOfTree V)//виведення всього дерева на екран
		{
			string result = "";
			if (V.left != null)
			{
				result += SeeTree(V.left)+" ";
			}
			if (V.right != null)
			{
				result += SeeTree(V.right)+" ";
			}
			result += V.Name+" ";
			return result;
		}
	}
	public class ElementOfTree
	{
		private string _name;
		public string Name
		{
			get {return _name;} set
			{
				if (value.Length > 3 && value.Length <= 10)
				{
					_name = value;
					return;
				}
				throw new Exception("Непідходяще ім'я");
			}
		}
		public ElementOfTree? left, right;
		public ElementOfTree(string name)
		{
			Name = name;
		}
	}
}
