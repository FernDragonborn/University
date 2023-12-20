//#include <iostream>;
//#include <cmath>;
//#include <windows.h>;
//using namespace std;
//int main()
//{
//	SetConsoleOutputCP(1251);
//	long long temp;
//	short a = 0;
//	int b = 0;
//	double c = 0;
//	double d = 0;
//	double result = 0;
//	cout << ("ОДЗ: с >= 0, b-a/2 != 0") << endl;
//	cout << ("\nВведіть а => ");
//	cin >> temp;
//	if (temp < SHRT_MIN || temp > SHRT_MAX)
//	{
//		cout << "Помилка: дане число не входить в діапазон чисел для типу даних short";
//		return -1;
//	}
//	a = temp;
//	cout << ("Подача в ЕОМ => ") << a << endl;
//	cout << ("\nВведіть b => ");
//	cin >> temp;
//	
//	if (temp < INT_MIN || temp > INT_MAX)
//	{
//		cout << "Помилка: дане число не входить в діапазон чисел для типу даних int";
//		return -1;
//	}
//	b = temp;
//	cout << ("Подача в ЕОМ => ") << b << endl;
//	if (b - a / 2 == 0)
//	{
//		cout << "Не можна ділити на 0";
//		return -1;
//	}
//	cout << ("\nВведіть c => ");
//	cin >> c;
//	cout << ("Подача в ЕОМ => ") << c << endl;
//	if (c < 0)
//	{
//		cout << "Не допустиме значення. \"с\" повинно бути більше 0";
//		return -1;
//	}
//	cout << ("\nВведіть d => ");
//	cin >> d;
//	cout << ("Подача в ЕОМ => ") << d << endl;
//	result = (c + d * 4 - sqrt(123 * c)) / (b - a / 2);
//	cout << "\nРезультат: " << result << endl;
//	return 0;
//}