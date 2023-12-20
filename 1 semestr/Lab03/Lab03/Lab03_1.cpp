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
	cout << ("ОДЗ: с >= 0, b-a/2 != 0") << endl;
	cout << ("\nВведіть а => ");
	cin >> a;
	cout << ("Подача в ЕОМ => ") << a << endl;
	cout << ("\nВведіть b => ");
	cin >> b;
	cout << ("Подача в ЕОМ => ") << b << endl;
	if(b - a/2 == 0)
	{
		cout << "Не можна ділити на 0";
		return 0;
	}
	cout << ("\nВведіть c => ");
	cin >> c;
	cout << ("Подача в ЕОМ => ") << c << endl;
	if (c < 0) 
	{
		cout << "Не допустиме значення. \"с\" новиннго бути більше 0";
		return 0;
	}
	cout << ("\nВведіть d => ");
	cin >> d;
	cout << ("Подача в ЕОМ => ") << d << endl;
	result = (c + d * 4 - sqrt(123 * c)) / (b - a / 2);
	cout << "\nРезультат: " << result << endl;
	return 0;
}