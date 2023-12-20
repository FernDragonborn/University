//#include <iostream>;
//#include <windows.h>;
//using namespace std;
//int main()
//{
//	SetConsoleOutputCP(1251);
//	double x, y; // x,y - координаты точки
//	double outR = 5, inR = 3; // outR - зовнішний радіус; inR - внтрішній радіус
//	bool result = 0;
//	cout << ("Перевірка, чи належать задані користувачем точки Х та Y функції x >= 0 && sqrt((x*x)+(y*y)) => 3 && sqrt((x*x)+(y*y)) =< 5") << endl;
//	cout << ("Якщо результат Yes - точка входить, No - точка не входить.") << endl;
//	cout << ("Введіть х=> ");
//	cin >> x;
//	cout << ("Подача в ЕОМ =>") << x << endl;
//	cout << ("Введіть y=> ");
//	cin >> y;
//	cout << ("Подача в ЕОМ =>") << y << endl;
//	
//	double actualR = sqrt((x * x) + (y * y));
//	result = x >= 0 && inR <= actualR && outR >= actualR;
//	cout << "Результат: " << result;
//	return 0;
//}