x_min = 0;
x_max = %pi;
step = 0.1;
x = x_min:step:x_max;
y = %e ^ (sin(x+2));
clf();
plot(x, y);
xlabel('x');
ylabel('y');
data = [x', y'];
title('Графік функції e ^ (sin(x+2))');
xgrid;
disp('x          y');
for i = 1:length(x)
    disp([x(i), y(i)]);
end
