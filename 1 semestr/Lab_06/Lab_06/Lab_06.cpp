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
		printf("Вводьте числа більші ща 0 та натискайте ентер.\nЇх кілкьість буде пдіраховано, а також кліькість подвіних парних буде підраховано\nПри введені 0 програма буде завершена\n\n");
	do {
		handler();
		printf("\nВведіть будь-яке число окрім 0, якщо бажаєте продовжити: ");
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
		cout << i + 1 << " число: ";
		cin >> temp;
		if (temp < 0 || temp > 255) { cout << "Число виходить за діапазон 0 - 255\n"; continue; }
		input = temp;
		if (input == 0) { break; }
		i++;
		DoubleEvenCounter += isDoubleEven(input);
	};
	cout << "Всього ввдено " << i << " чисел.\nПодвійних кратних із них: " << DoubleEvenCounter << "\n";
}

short isDoubleEven(unsigned char input) 
{
	if (input % 4 == 0) {
		return 1;
	}
	return 0;
}