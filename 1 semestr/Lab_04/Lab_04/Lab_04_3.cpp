#include <iostream>
#include <windows.h>;
using namespace std;

int main()
{
	SetConsoleOutputCP(1251);
	int temp;
	short x, a, b;
	cout << "������ �: ";
	cin >> temp;
	if (temp < SHRT_MIN || temp > SHRT_MAX)
	{
		cout << "�������: ���� ����� �� ������� � ������� ����� ��� ���� ����� short";
		return -1;
	}
	a = temp;
	cout << "������ �: ";
	cin >> temp;
	if (temp < SHRT_MIN || temp > SHRT_MAX)
	{
		cout << "�������: ���� ����� �� ������� � ������� ����� ��� ���� ����� short";
		return -1;
	}
	b = temp;
	if (a > b) {
		if(a == 0) {
			cout << "���� �������: � = (a - b) / a - 3 \n�� 0 ����� �� �����";
			return -1;
		}
		cout << "a > b\n���� �������: � = (a - b) / a - 3 " << endl;
		temp = (a - b) / a - 3;
	}
	else if (a == b) {
		cout << "a == b\n���� �������: � = 2" << endl;
		temp = 2;
	}
	else {
		if (b == 0) {
			cout << "���� �������: � = pow(a, 3) + 1) / b \n�� 0 ����� �� �����";
			return -1;
		}
		cout << "a < b\n���� �������: � = pow(a, 3) + 1) / b" << endl;
		temp = (pow(a, 3) + 1) / b;
	}
	if (temp < SHRT_MIN || temp > SHRT_MAX)
	{
		cout << "�������: ���������� ����� �� ������� � ������� ����� ��� ���� ����� short";
		return -1;
	}
	x = temp;
	cout << "���������: " << x << endl;
	return 0;
}