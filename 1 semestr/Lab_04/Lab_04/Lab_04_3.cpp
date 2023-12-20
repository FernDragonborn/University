#include <iostream>
#include <windows.h>;
using namespace std;

int main()
{
	SetConsoleOutputCP(1251);
	int temp;
	short x, a, b;
	cout << "Введіть х: ";
	cin >> temp;
	if (temp < SHRT_MIN || temp > SHRT_MAX)
	{
		cout << "Помилка: дане число не входить в діапазон чисел для типу даних short";
		return -1;
	}
	a = temp;
	cout << "Введіть у: ";
	cin >> temp;
	if (temp < SHRT_MIN || temp > SHRT_MAX)
	{
		cout << "Помилка: дане число не входить в діапазон чисел для типу даних short";
		return -1;
	}
	b = temp;
	if (a > b) {
		if(a == 0) {
			cout << "ваше рівняння: х = (a - b) / a - 3 \nна 0 ділити не можна";
			return -1;
		}
		cout << "a > b\nваше рівняння: х = (a - b) / a - 3 " << endl;
		temp = (a - b) / a - 3;
	}
	else if (a == b) {
		cout << "a == b\nваше рівняння: х = 2" << endl;
		temp = 2;
	}
	else {
		if (b == 0) {
			cout << "ваше рівняння: х = pow(a, 3) + 1) / b \nна 0 ділити не можна";
			return -1;
		}
		cout << "a < b\nваше рівняння: х = pow(a, 3) + 1) / b" << endl;
		temp = (pow(a, 3) + 1) / b;
	}
	if (temp < SHRT_MIN || temp > SHRT_MAX)
	{
		cout << "Помилка: обраховане число не входить в діапазон чисел для типу даних short";
		return -1;
	}
	x = temp;
	cout << "Результат: " << x << endl;
	return 0;
}