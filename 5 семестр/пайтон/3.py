import re

input_string = "32 +3 -2 *1 *5/ 4% 6 //1 ** 0.2"
input_string = input_string.replace(" ", "")

# Регулярний вираз для чисел і операторів
pattern = r"(\d+(?:\.\d+)?)|([\+\-\*/%//\*\*])"

# Парсинг рядка
tokens = re.findall(pattern, input_string)

# Витягаємо числа та оператори
parsed_tokens = [token[0] if token[0] else token[1] for token in tokens]

print(parsed_tokens)