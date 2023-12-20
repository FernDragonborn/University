#include <iostream>
#include <Windows.h>
#include <math.h>
using namespace std;

int main()
{
	SetConsoleOutputCP(1251);
	short isRepeat = 0;
	float x;
	int n;
	double result = 0;	
	do {
		cout << "������ x: ";
		cin >> x;
		if (x < 0 || x > 1) {
			cout << "�������� � ������� ���� �� 0 �� 1";
			return -1;
		}
		cout << "������ n: ";
		cin >> n;
		if (n < 0) {
			cout << "ʳ��곳��� �������� �� ���� ���� ��'�����";
			return -1;
		}

		result = x;
		for (int i = 2; i <= n; i++)
		{
			result += result * (x / i);
		}
		cout << "���������: " << result << endl;

		float epsilon;
		cout << "\n������ ������: ";
		cin >> epsilon;
		result = 1;
		float prevResult = result;
		int i = 1;
		while (epsilon >= fabs(result - prevResult) && i < 10000) {
			prevResult = result;
			result += result * (x / i);
			i++;
		}
		cout << "��������� �� �������: " << result << endl;
		cout << "ʳ������ ��������: " << i << endl;

		cout << "����������� �����: " << exp(x) - 1 << endl;

		cout << "����� 1 ��� ���������� ����������, ��� 0 ��� ���������� ��������";
		cin >> isRepeat;
		if (isRepeat != 1) isRepeat = 0;
	} while (isRepeat);
	return 0;
}