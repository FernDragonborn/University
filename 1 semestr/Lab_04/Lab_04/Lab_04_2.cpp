//#include <iostream>;
//#include <windows.h>;
//using namespace std;
//int main()
//{
//    SetConsoleOutputCP(1251);
//    float temp;
//    float x, y; // x,y - ���������� �����
//    float outR = 5, inR = 3; // outR - �������� �����; inR - ������� �����
//    bool result = 0;
//    cout << ("��������, �� �������� ����� ������������ ����� � �� Y ������� x >= 0 && sqrt((x*x)+(y*y)) => 3 && sqrt((x*x)+(y*y)) =< 5") << endl;
//    cout << ("���� ��������� Yes - ����� �������, No - ����� �� �������.") << endl;
//    cout << ("������ �=> ");
//    cin >> temp;
//    if ((fabs(temp) <= FLT_MIN) || (fabs(temp) >= FLT_MAX))
//    {
//        cout << "�������: ���� ����� �� ������� � ������� ����� ��� ���� ����� float";
//        return -1;
//    }
//    x = temp;
//    cout << ("������ � ��� => ") << x << endl;
//    cout << ("������ y=> ");
//    cin >> temp;
//    if ((fabs(temp) <= FLT_MIN) || (fabs(temp) >= FLT_MAX))
//    {
//        cout << "�������: ���� ����� �� ������� � ������� ����� ��� ���� ����� float";
//        return -1;
//    }
//    y = temp;
//    cout << ("������ � ��� => ") << y << endl;
//
//    double actualR = sqrt((x * x) + (y * y));
//    result = x >= 0 && inR <= actualR && outR >= actualR;
//    cout << "���������: " << result;
//    return 0;
//}