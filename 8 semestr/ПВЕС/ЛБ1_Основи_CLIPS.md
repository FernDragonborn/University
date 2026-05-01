# Лабораторна робота №1

## Вивчення основних можливостей і базових команд середовища CLIPS

### 1. Мета роботи

Вивчити особливості застосування середовища CLIPS для створення експертних систем.

---

### 2. Хід роботи

#### 2.1. Додавання фактів у систему

Виконаємо послідовно команди для додавання фактів:

```
CLIPS> (clear)
CLIPS> (assert (color red))
==> f-0     (color red)
<Fact-0>
CLIPS> (assert (color blue) (value 3 4))
==> f-1     (color blue)
==> f-2     (value 3 4)
<Fact-2>
CLIPS> (assert (suggest "Turn on the left"))
==> f-3     (suggest "Turn on the left")
<Fact-3>
```

Перевіримо список фактів:

```
CLIPS> (facts)
f-0     (color red)
f-1     (color blue)
f-2     (value 3 4)
f-3     (suggest "Turn on the left")
For a total of 4 facts.
```

Усі 4 факти додано коректно. Факт `(value 3 4)` містить три поля: символ `value` та два цілих числа `3` і `4`.

#### 2.2. Факт про лампу в коридорі

Додамо факт, що означає «лампу в коридорі увімкнено»:

```
CLIPS> (assert (lamp corridor on))
==> f-4     (lamp corridor on)
<Fact-4>
```

Факт `(lamp corridor on)` складається з трьох полів: тип об'єкта (`lamp`), місце (`corridor`) та стан (`on`).

#### 2.3. Додавання та вибіркове видалення фактів

Додамо послідовність з 8 фактів:

```
CLIPS> (clear)
CLIPS> (assert (weather sunny))
==> f-0     (weather sunny)
<Fact-0>
CLIPS> (assert (temperature 22))
==> f-1     (temperature 22)
<Fact-1>
CLIPS> (assert (wind north 5))
==> f-2     (wind north 5)
<Fact-2>
CLIPS> (assert (humidity 60))
==> f-3     (humidity 60)
<Fact-3>
CLIPS> (assert (pressure 750))
==> f-4     (pressure 750)
<Fact-4>
CLIPS> (assert (visibility good))
==> f-5     (visibility good)
<Fact-5>
CLIPS> (assert (season spring))
==> f-6     (season spring)
<Fact-6>
CLIPS> (assert (forecast rain))
==> f-7     (forecast rain)
<Fact-7>
```

Поточний список:

```
CLIPS> (facts)
f-0     (weather sunny)
f-1     (temperature 22)
f-2     (wind north 5)
f-3     (humidity 60)
f-4     (pressure 750)
f-5     (visibility good)
f-6     (season spring)
f-7     (forecast rain)
For a total of 8 facts.
```

Видалимо факти з індексами 0, 3 та 5. Для видалення факту f-3 використаємо функцію додавання:

```
CLIPS> (retract 0 (+ 1 2) 5)
<== f-0     (weather sunny)
<== f-3     (humidity 60)
<== f-5     (visibility good)
```

Перевіримо результат:

```
CLIPS> (facts)
f-1     (temperature 22)
f-2     (wind north 5)
f-4     (pressure 750)
f-6     (season spring)
f-7     (forecast rain)
For a total of 5 facts.
```

Факти f-0, f-3 та f-5 успішно видалено. Вираз `(+ 1 2)` обчислився як `3`, що вказує на факт f-3.

#### 2.4. Арифметичні операції

Дано цілі числа: 5, 9, 20, 1. Виконаємо арифметичні дії:

**Додавання:**

```
CLIPS> (+ 5 9 20 1)
35
```

**Віднімання:**

```
CLIPS> (- 20 1)
19
CLIPS> (- 20 5 9 1)
5
```

**Множення:**

```
CLIPS> (* 5 9)
45
CLIPS> (* 20 1)
20
```

**Ділення:**

```
CLIPS> (/ 20 5)
4
CLIPS> (div 20 9)
2
CLIPS> (/ 9 5)
1.8
```

Функція `div` виконує цілочислове ділення (результат = 2), тоді як `/` повертає речове число (результат = 1.8).

---

### 3. Висновки

У ході виконання лабораторної роботи вивчено основні можливості середовища CLIPS:

1. Команда `assert` додає факти до робочої пам'яті. Один виклик може додати кілька фактів одночасно. Кожен факт отримує унікальний індекс.

2. Команда `retract` видаляє факти за індексом. Аргументом може бути як числова константа, так і вираз — наприклад, `(+ 1 2)` для обчислення індексу динамічно.

3. Факти у CLIPS — це списки атомарних значень примітивних типів (symbol, string, integer, float). Вони є основною формою подання даних у робочій пам'яті системи.

4. Арифметичні функції CLIPS використовують префіксну нотацію і підтримують довільну кількість аргументів: `(+ 5 9 20 1)` = 35.
