#include <iostream>
#include <math.h>
#include <Windows.h>
using namespace std;

short isDoubleEven(unsigned char);
void handler();

int main()
{
	SetConsoleOutputCP(1251);
	int repeat = 0;
		printf("������� ����� ����� �� 0 �� ���������� �����.\n�� �������� ���� ����������, � ����� ������� ������� ������ ���� ����������\n��� ������ 0 �������� ���� ���������\n\n");
	do {
		handler();
		printf("\n������ ����-��� ����� ���� 0, ���� ������ ����������: ");
		cin >> repeat;
	} while (repeat != 0);
	return 0;
}

void handler()
{
	unsigned char input = 0;
	short temp = 0;
	int i = 0, DoubleEvenCounter = 0;
	while (true) {
		cout << i + 1 << " �����: ";
		cin >> temp;
		if (temp < 0 || temp > 255) { cout << "����� �������� �� ������� 0 - 255\n"; continue; }
		input = temp;
		if (input == 0) { break; }
		i++;
		DoubleEvenCounter += isDoubleEven(input);
	};
	cout << "������ ������ " << i << " �����.\n�������� ������� �� ���: " << DoubleEvenCounter << "\n";
}

short isDoubleEven(unsigned char input) 
{
	if (input % 4 == 0) {
		return 1;
	}
	return 0;
}