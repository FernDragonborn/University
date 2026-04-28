import re

standard_input = [
    "32 +3 -2 *1 *5/ 4% 6 //1 ** 0.2",  # Завдання 2.1: недо-калькулятор
    "1.5 3.2 -4.8 0.0 2.9",             # Завдання 2.2: список чисел
    "1 5 -6",                           # Завдання 2.3: коефіцієнти квадратного рівняння
    "10 2",                             # Завдання 2.4: два цілі числа, m ділиться на n
    "7 3"                               # Завдання 2.4: два цілі числа, m не ділиться на n
]

print('\n\nЗавдання 2.1')
operations = {
        "+": lambda x, y: x + y,
        "-": lambda x, y: x - y,
        "*": lambda x, y: x * y,
        "/": lambda x, y: x / y,
        "%": lambda x, y: x % y,
        "**": lambda x, y: x ** y,
        "//": lambda x, y: x // y,
    }

def perform_calculation(operation: str, number: float, argument: float) -> float:
    if operation in ["/", "//", "%"] and argument == 0:
        raise ZeroDivisionError(f"Операція {operation} з нулем неможлива.")
    if operation not in operations:
        raise ValueError(f"Невідомий оператор: {operation}")
    return operations[operation](number, argument)

def parse_expression(expression: str) -> list:
    expression = expression.replace(" ", "")
    pattern = r"(\d+(?:\.\d+)?)|(\*\*|//|[\+\-\*/%])"
    tokens = re.findall(pattern, expression)
    return [token[0] if token[0] else token[1] for token in tokens]

user_input = input("Введіть математичний вираз: ")
parsed_tokens = parse_expression(user_input)

number = float(parsed_tokens[0])
i = 1
while i < len(parsed_tokens):
    operation = parsed_tokens[i]
    argument = float(parsed_tokens[i + 1])

    result = perform_calculation(operation, number, argument)
    print(f'{number} {operation} {argument} = {result}')
    number = result

    i += 2

print(f'Результат: {number}')



print('\n\nЗавдання 2.2')
sequence = input("Введіть послідовність дійсних чисел через пробіл: ")
numbers = list(map(float, sequence.split()))
min_number = min(numbers)
print(f"Мінімальне число: {min_number}")


print('\n\nЗавдання 2.3')
coefficients = input("Введіть коефіцієнти a, b, c через пробіл: ").split()
a, b, c = map(float, coefficients)
discriminant = b**2 - 4*a*c
print("ТАК" if discriminant >= 0 else "НІ")


print('\n\nЗавдання 2.4')
mn = input("Введіть два цілих числа через пробіл: ").split()
m, n = map(int, mn)
result = (m // n if m % n == 0 else m * n) if n != 0 else "Ділення на нуль неможливе"
print(f"Результат: {result}")