//#include <iostream>;
//#include <windows.h>;
//using namespace std;
//int main()
//{
//    SetConsoleOutputCP(1251);
//    float temp;
//    float x, y; // x,y - координаты точки
//    float outR = 5, inR = 3; // outR - зовнішний радіус; inR - внтрішній радіус
//    bool result = 0;
//    cout << ("Перевірка, чи належать задані користувачем точки Х та Y функції x >= 0 && sqrt((x*x)+(y*y)) => 3 && sqrt((x*x)+(y*y)) =< 5") << endl;
//    cout << ("Якщо результат Yes - точка входить, No - точка не входить.") << endl;
//    cout << ("Введіть х=> ");
//    cin >> temp;
//    if ((fabs(temp) <= FLT_MIN) || (fabs(temp) >= FLT_MAX))
//    {
//        cout << "Помилка: дане число не входить в діапазон чисел для типу даних float";
//        return -1;
//    }
//    x = temp;
//    cout << ("Подача в ЕОМ => ") << x << endl;
//    cout << ("Введіть y=> ");
//    cin >> temp;
//    if ((fabs(temp) <= FLT_MIN) || (fabs(temp) >= FLT_MAX))
//    {
//        cout << "Помилка: дане число не входить в діапазон чисел для типу даних float";
//        return -1;
//    }
//    y = temp;
//    cout << ("Подача в ЕОМ => ") << y << endl;
//
//    double actualR = sqrt((x * x) + (y * y));
//    result = x >= 0 && inR <= actualR && outR >= actualR;
//    cout << "Результат: " << result;
//    return 0;
//}