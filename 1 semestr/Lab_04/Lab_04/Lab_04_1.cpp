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
//	cout << ("���: � >= 0, b-a/2 != 0") << endl;
//	cout << ("\n������ � => ");
//	cin >> temp;
//	if (temp < SHRT_MIN || temp > SHRT_MAX)
//	{
//		cout << "�������: ���� ����� �� ������� � ������� ����� ��� ���� ����� short";
//		return -1;
//	}
//	a = temp;
//	cout << ("������ � ��� => ") << a << endl;
//	cout << ("\n������ b => ");
//	cin >> temp;
//	
//	if (temp < INT_MIN || temp > INT_MAX)
//	{
//		cout << "�������: ���� ����� �� ������� � ������� ����� ��� ���� ����� int";
//		return -1;
//	}
//	b = temp;
//	cout << ("������ � ��� => ") << b << endl;
//	if (b - a / 2 == 0)
//	{
//		cout << "�� ����� ����� �� 0";
//		return -1;
//	}
//	cout << ("\n������ c => ");
//	cin >> c;
//	cout << ("������ � ��� => ") << c << endl;
//	if (c < 0)
//	{
//		cout << "�� ��������� ��������. \"�\" ������� ���� ����� 0";
//		return -1;
//	}
//	cout << ("\n������ d => ");
//	cin >> d;
//	cout << ("������ � ��� => ") << d << endl;
//	result = (c + d * 4 - sqrt(123 * c)) / (b - a / 2);
//	cout << "\n���������: " << result << endl;
//	return 0;
//}