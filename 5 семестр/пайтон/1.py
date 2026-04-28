import math
standard_input = [5,2]
cathetus_a = int(input())
cathetus_b = int(input())

limit_a = -5
limit_b = 1

hypotenuse = int(math.sqrt(cathetus_a**2 + cathetus_b**2))

print(hypotenuse > limit_a and hypotenuse < limit_b)