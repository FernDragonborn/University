function y = myEquation(x)
    y = 3*x - cos(x) - 1;
endfunction
x0 = 1;
root = fsolve(x0, myEquation);
disp("Корінь рівняння: ");
disp(root);
