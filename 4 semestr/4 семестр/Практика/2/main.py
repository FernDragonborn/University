def f(x):
    equation = x**3 - 3 * x**2 + 3
    return equation

def bisection_method(f, a, b, epsilon):
    if f(a) * f(b) >= 0:
        raise ValueError("Функція повинна мати різні знаки в кінцевих точках a та b.")
    while (b - a) / 2.0 > epsilon:
        c = (a + b) / 2.0
        if f(c) == 0:
            break
        elif f(c) * f(a) < 0:
            b = c
        else:
            a = c
    return c

a, b = -5, 5  
epsilon = 1e-5

root = bisection_method(f, a, b, epsilon)
print(f"Корінь знайдено в: {root}")