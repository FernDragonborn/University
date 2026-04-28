using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
	public class BinaryInject 
	{
		public static void BinaryInjectionSort(int[] array)
		{
			for (int i = 1; i < array.Length; i++)
			{
				int key = array[i];
				int left = 0;
				int right = i - 1;

				while (left <= right)
				{
					int mid = left + (right - left) / 2;
					if (array[mid] > key)
					{
						right = mid - 1;
					}
					else
					{
						left = mid + 1;
					}
				}
				for (int j = i - 1; j >= left; j--)
				{
					array[j + 1] = array[j];
				}
				array[left] = key;
            }
		}
	}
}
