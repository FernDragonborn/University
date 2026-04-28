function F = system_of_equations(variables)
    x = variables(1);
    y = variables(2);
    F = [0.25* ( x^2 - y^2 ) - x^2 * y^2 + 0.5;
        x * y * (x^2 -y^2) + 0.5];
endfunction

initial_guess = [0.5; 0.5];

solution = fsolve(initial_guess, system_of_equations);
x = solution(1);
y = solution(2);

disp("Рішення:");
disp("x = " + string(x));
disp("y = " + string(y));
