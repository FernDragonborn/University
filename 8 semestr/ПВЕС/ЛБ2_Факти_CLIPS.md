# Лабораторна робота №2

## Факти в середовищі CLIPS

### 1. Мета роботи

Вивчити технологію формування бази даних у середовищі CLIPS.

---

### 2. Хід роботи

#### 2.1. Автоматичне додавання фактів (deffacts)

Визначимо список фактів про автомобілі, що автоматично додаються при скиданні середовища:

```
CLIPS> (clear)
CLIPS> (deffacts cars
  (car opel black 2019)
  (car toyota white 2021)
  (car bmw blue 2020)
  (car ford red 2018)
  (car honda silver 2022))
```

Виконаємо скидання середовища та перевіримо список фактів:

```
CLIPS> (reset)
CLIPS> (facts)
f-0     (initial-fact)
f-1     (car opel black 2019)
f-2     (car toyota white 2021)
f-3     (car bmw blue 2020)
f-4     (car ford red 2018)
f-5     (car honda silver 2022)
For a total of 6 facts.
```

П'ять фактів про автомобілі автоматично додано при виконанні `(reset)`. Факт `f-0 (initial-fact)` створюється системою автоматично.

#### 2.2. Визначення шаблону мобільного телефону

Створимо шаблон для опису мобільного телефону з трьома полями — модель, колір та тип корпусу:

```
CLIPS> (deftemplate phone "Template for a mobile phone"
  (slot model)
  (slot color)
  (slot body-type))
```

Переконаємось, що шаблон створено:

```
CLIPS> (ppdeftemplate phone)
(deftemplate MAIN::phone "Template for a mobile phone"
   (slot model)
   (slot color)
   (slot body-type))
```

#### 2.3. Додавання шаблонних фактів

Додамо кілька моделей мобільних телефонів:

```
CLIPS> (assert (phone (model "iPhone 15") (color black) (body-type monoblock)))
==> f-6     (phone (model "iPhone 15") (color black) (body-type monoblock))
<Fact-6>
CLIPS> (assert (phone (model "Samsung S24") (color white) (body-type monoblock)))
==> f-7     (phone (model "Samsung S24") (color white) (body-type monoblock))
<Fact-7>
CLIPS> (assert (phone (model "Motorola Razr") (color silver) (body-type foldable)))
==> f-8     (phone (model "Motorola Razr") (color silver) (body-type foldable))
<Fact-8>
CLIPS> (assert (phone (model "Nokia 3310") (color blue) (body-type monoblock)))
==> f-9     (phone (model "Nokia 3310") (color blue) (body-type monoblock))
<Fact-9>
```

Перевіримо список фактів:

```
CLIPS> (facts)
f-0     (initial-fact)
f-1     (car opel black 2019)
f-2     (car toyota white 2021)
f-3     (car bmw blue 2020)
f-4     (car ford red 2018)
f-5     (car honda silver 2022)
f-6     (phone (model "iPhone 15") (color black) (body-type monoblock))
f-7     (phone (model "Samsung S24") (color white) (body-type monoblock))
f-8     (phone (model "Motorola Razr") (color silver) (body-type foldable))
f-9     (phone (model "Nokia 3310") (color blue) (body-type monoblock))
For a total of 10 facts.
```

#### 2.4. Зміна фактів командою modify

Змінимо колір автомобіля BMW з blue на green. Для цього потрібно використовувати шаблонний факт. Спочатку створимо шаблон для автомобілів:

```
CLIPS> (clear)
CLIPS> (deftemplate car "Template for a car"
  (slot brand)
  (slot color)
  (slot year))

CLIPS> (deffacts garage
  (car (brand opel) (color black) (year 2019))
  (car (brand toyota) (color white) (year 2021))
  (car (brand bmw) (color blue) (year 2020)))

CLIPS> (reset)
CLIPS> (facts)
f-0     (initial-fact)
f-1     (car (brand opel) (color black) (year 2019))
f-2     (car (brand toyota) (color white) (year 2021))
f-3     (car (brand bmw) (color blue) (year 2020))
For a total of 4 facts.
```

Змінимо колір BMW (f-3) на green:

```
CLIPS> (modify 3 (color green))
<== f-3     (car (brand bmw) (color blue) (year 2020))
==> f-4     (car (brand bmw) (color green) (year 2020))
```

Команда `modify` видалила старий факт f-3 і створила новий f-4 зі зміненим значенням слоту `color`. Індекс факту змінився з 3 на 4.

Тепер додамо шаблон телефону і змінимо колір Nokia:

```
CLIPS> (deftemplate phone "Template for a mobile phone"
  (slot model)
  (slot color)
  (slot body-type))

CLIPS> (assert (phone (model "Nokia 3310") (color blue) (body-type monoblock)))
==> f-5     (phone (model "Nokia 3310") (color blue) (body-type monoblock))
<Fact-5>

CLIPS> (modify 5 (color yellow))
<== f-5     (phone (model "Nokia 3310") (color blue) (body-type monoblock))
==> f-6     (phone (model "Nokia 3310") (color yellow) (body-type monoblock))
```

Перевіримо фінальний стан:

```
CLIPS> (facts)
f-0     (initial-fact)
f-1     (car (brand opel) (color black) (year 2019))
f-2     (car (brand toyota) (color white) (year 2021))
f-4     (car (brand bmw) (color green) (year 2020))
f-6     (phone (model "Nokia 3310") (color yellow) (body-type monoblock))
For a total of 5 facts.
```

---

### 3. Висновки

У ході виконання лабораторної роботи вивчено технологію роботи з фактами у CLIPS:

1. Конструктор `deffacts` дозволяє визначити набір фактів, що автоматично додаються до робочої пам'яті при виконанні команди `(reset)`.

2. Конструктор `deftemplate` визначає структурований шаблон факту зі слотами. Шаблонні факти (невпорядковані) зручніші за прості — кожне поле має ім'я, порядок слотів не має значення.

3. Команда `modify` дозволяє змінити значення окремих слотів шаблонного факту. Внутрішньо вона видаляє старий факт і створює новий з оновленими значеннями — тому індекс факту змінюється.

4. Простий слот (`slot`) зберігає одне атомарне значення, складений слот (`multislot`) — список значень.
