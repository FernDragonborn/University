#include <iostream>
#include <math.h>

using namespace std;

int main()
{
	int x;
	double e = 2.71828182846, epsilon;
	long res = 0;
	cout << "Input epsilon: ";
	cin >> epsilon;
	cout << "Input x: ";
	cin >> x;
	for (int i = 0; i < n; i++)
	{
		res += pow(e, i) - 1;
	}
	cout << "result: " << res;
	return 0;
}

