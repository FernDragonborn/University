#include <Windows.h>
#include <iostream>
using namespace std;
int main()
{
	SetConsoleOutputCP(1251);
	int c, d, res;
	cout << "������ a: ";
	cin >> c;
	cout << "������ b: ";
	cin >> d;
	res = c + 4 * d;
	cout << "��������� = " << res << endl;
	return 0;
}