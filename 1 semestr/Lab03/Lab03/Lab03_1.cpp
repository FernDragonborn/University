#include <iostream>;
#include <cmath>;
#include <windows.h>;
using namespace std;
int main()
{
	SetConsoleOutputCP(1251);
	short a = 0;
	int b = 0;
	double c = 0;
	double d = 0;
	double result = 0;
	cout << ("���: � >= 0, b-a/2 != 0") << endl;
	cout << ("\n������ � => ");
	cin >> a;
	cout << ("������ � ��� => ") << a << endl;
	cout << ("\n������ b => ");
	cin >> b;
	cout << ("������ � ��� => ") << b << endl;
	if(b - a/2 == 0)
	{
		cout << "�� ����� ����� �� 0";
		return 0;
	}
	cout << ("\n������ c => ");
	cin >> c;
	cout << ("������ � ��� => ") << c << endl;
	if (c < 0) 
	{
		cout << "�� ��������� ��������. \"�\" �������� ���� ����� 0";
		return 0;
	}
	cout << ("\n������ d => ");
	cin >> d;
	cout << ("������ � ��� => ") << d << endl;
	result = (c + d * 4 - sqrt(123 * c)) / (b - a / 2);
	cout << "\n���������: " << result << endl;
	return 0;
}