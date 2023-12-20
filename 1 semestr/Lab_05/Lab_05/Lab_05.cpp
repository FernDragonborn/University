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
		cout << "Введіть x: ";
		cin >> x;
		if (x < 0 || x > 1) {
			cout << "Значення х повинно бути від 0 до 1";
			return -1;
		}
		cout << "Введіть n: ";
		cin >> n;
		if (n < 0) {
			cout << "Кількіість ітерацій не можу бути від'ємною";
			return -1;
		}

		result = x;
		for (int i = 2; i <= n; i++)
		{
			result += result * (x / i);
		}
		cout << "Результат: " << result << endl;

		float epsilon;
		cout << "\nВведіть епсілон: ";
		cin >> epsilon;
		result = 1;
		float prevResult = result;
		int i = 1;
		while (epsilon >= fabs(result - prevResult) && i < 10000) {
			prevResult = result;
			result += result * (x / i);
			i++;
		}
		cout << "Складання із точністю: " << result << endl;
		cout << "Кількість ітерацій: " << i << endl;

		cout << "Контрольний вираз: " << exp(x) - 1 << endl;

		cout << "Ведіть 1 для повторення розрахунків, або 0 для завершення програми";
		cin >> isRepeat;
		if (isRepeat != 1) isRepeat = 0;
	} while (isRepeat);
	return 0;
}