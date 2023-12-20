#include <Windows.h>
#include <iostream>
using namespace std;
int main()
{
	SetConsoleOutputCP(1251);
	int c, d, res;
	cout << "¬вед≥ть a: ";
	cin >> c;
	cout << "¬вед≥ть b: ";
	cin >> d;
	res = c + 4 * d;
	cout << "–езультат = " << res << endl;
	return 0;
}