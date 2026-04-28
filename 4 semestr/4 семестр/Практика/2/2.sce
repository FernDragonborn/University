function y = f(x)
    y = x**3 - 3 * x**2 + 3;
endfunction

function root = bisection_method(f, a, b, epsilon)
    if f(a) * f(b) >= 0 then
        error("Функція повинна мати різні знаки в кінцевих точках a та b.");
    end
    c = a;
    while (b - a) / 2 > epsilon do
        c = (a + b) / 2;
        if f(c) == 0 then
            break;
        elseif f(c) * f(a) < 0 then
            b = c;
        else
            a = c;
        end
    end
    root = c;
endfunction

a = -5;
b = 5;
epsilon = 1e-5;

root = bisection_method(f, a, b, epsilon);

disp("Корінь знайдено в: " + string(root));

x_initial = -5;
root_fsolve = fsolve(x_initial, f);
disp("Перевірка за допомогою fsolve");
disp("Корінь знайдено в: " + string(root_fsolve));
