#include <iostream>
#include <time.h>
#include <stdlib.h>
#include <Windows.h>
#include <stdlib.h>

using namespace std;

void randomizeArray(unsigned short[], int);
void inputArray(unsigned short[], int);
void printArr(const unsigned short[], int);
double countInRangeAmount(unsigned short[], int, unsigned short, unsigned short);

int main()
{
	SetConsoleOutputCP(1251);
	int repeat = 0;
	do
	{
		system("cls");
		int const MAX_SIZE = 20;
		unsigned short arr[MAX_SIZE];
		short c, d;
		int mode, size;
		do {
			printf("������ ����� ������ (�� 1 �� 20): ");
			cin >> size;
		} while (size < 1 || size > 20);
		printf("������ ����� ���������� ������: \n1 - ��� �������\n2 - ��� �����������\n");
		cin >> mode;
		if (mode == 1){ 
			inputArray(arr, size); 
		}
		else { 
			randomizeArray(arr, size); 
		}
		printArr(arr, size);
		printf("������ ����� ��� (�) �� ������ (d). ���� ����� ��� ���� ������ �� ������, �� ������� �����������\n");
		do{	
			printf("������ �: ");
			cin >> c;
			printf("������ d: ");
			cin >> d;
		} while (c < 0 || d < c);
		int inRangeAmount = countInRangeAmount(arr, size, c, d);
		printf("\nʳ������� �������� ������, �� ������������� ���� � <= a[i] <= D: " + inRangeAmount);
		printf("\n������ ��������� ��������� ��������?\n��� ������ ������ 0\b");
		cin >> repeat;
	} while (repeat != 0);
	return 0;
}

void randomizeArray(unsigned short arr[], int arrSize)
{
	srand((unsigned)time(NULL));
	for (int i = 0; i < arrSize; i++)
		arr[i] = rand() % arrSize;
	return;
}

void inputArray(unsigned short arr[], int arrSize)
{
	for (int i = 0; i < arrSize; i++)
	{
		int temp;
		cout << ("������ ") << i << (" �������: ");
		cin >> temp;
		if (temp < 0 || temp > USHRT_MAX) {
			printf("������ ��������. ����� �� ������� � ������� 0 - 65535\n");
			i--;
			continue;
		}
		arr[i] = temp;
	}
}

void printArr(const unsigned short arr[], int arrSize)
{
	cout << "�������� ��������� ������\n";
	for (int i = 0; i < arrSize; i++)
		cout << arr[i] << "  ";
	cout << endl;
	return;
}

double countInRangeAmount(unsigned short arr[], int arrSize, unsigned short C, unsigned short D)
{
	int counter = 0;
	for (int i = 0; i < arrSize; i++)
		if (arr[i] >= C && arr[i] <= D)
			counter++;
	return counter;
}