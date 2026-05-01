# Лабораторна робота №3

## Правила в середовищі CLIPS

### 1. Мета роботи

Вивчити особливості реалізації правил у середовищі CLIPS для утворення бази знань.

---

### 2. Хід роботи

#### 2.1. Приклад «Конференція» — підрахунок учасників по містах

Створимо файл бази даних учасників конференції `conf.txt`:

```
(deffacts conf
  (conf Alejnov Odessa)
  (conf Ladak Odessa)
  (conf Slobodjanjuk Lvov)
  (conf Klitka Lvov)
  (conf Bojko Kiev)
  (conf Pustovit Odessa)
  (conf Spokojnij Odessa)
  (conf Shamis Odessa)
  (conf Lobovko Kiev)
  (conf Zadorozhna Lvov)
  (conf Javorskij Lvov))
```

Створимо файл з правилами `conference.clp`:

```
(defglobal ?*odessa* = 0)
(defglobal ?*kiev* = 0)
(defglobal ?*lvov* = 0)

(defrule begin
  (initial-fact)
  =>
  (printout t crlf "Members of conference" crlf))

(defrule odessa
  (conf ? Odessa)
  =>
  (bind ?*odessa* (+ ?*odessa* 1)))

(defrule kiev
  (conf ? Kiev)
  =>
  (bind ?*kiev* (+ ?*kiev* 1)))

(defrule lvov
  (conf ? Lvov)
  =>
  (bind ?*lvov* (+ ?*lvov* 1)))

(defrule result
  (declare (salience -1))
  (initial-fact)
  =>
  (printout t "from Odessa: " ?*odessa* crlf)
  (printout t "from Kiev: " ?*kiev* crlf)
  (printout t "from Lvov: " ?*lvov* crlf))
```

Виконання:

```
CLIPS> (clear)
CLIPS> (load conf.txt)
.........
TRUE
CLIPS> (load conference.clp)
.........
TRUE
CLIPS> (reset)
CLIPS> (run)

Members of conference
from Odessa: 5
from Kiev: 2
from Lvov: 4
```

Пояснення роботи програми:

- Глобальні змінні `?*odessa*`, `?*kiev*`, `?*lvov*` — лічильники для кожного міста.
- Правило `begin` активізується системним фактом `initial-fact` і виводить заголовок.
- Правила `odessa`, `kiev`, `lvov` — ядро програми. Символ `?` у лівій частині — універсальна підстановка, що замінює будь-яке прізвище. Кожне правило активізується стільки разів, скільки відповідних фактів є у БД.
- Функція `bind` — оператор присвоювання, збільшує лічильник на 1.
- Правило `result` має пріоритет `salience -1`, тому виконується останнім. Без нього воно конфліктувало б з правилом `begin` (однакова ліва частина).

#### 2.2. Підрахунок студентських оцінок

Створимо файл бази даних студентів `students.txt`:

```
(deffacts students
  (student Petrenko A)
  (student Koval B)
  (student Shevchenko A)
  (student Bondar C)
  (student Tkachuk B)
  (student Lysenko A)
  (student Melnyk B)
  (student Savchenko C)
  (student Moroz A)
  (student Rudenko B)
  (student Pavlenko A)
  (student Marchenko C))
```

Створимо файл з правилами `grades.clp`:

```
(defglobal ?*count-A* = 0)
(defglobal ?*count-B* = 0)
(defglobal ?*count-C* = 0)

(defrule header
  (initial-fact)
  =>
  (printout t crlf "=== Exam Results ===" crlf))

(defrule count-grade-A
  (student ? A)
  =>
  (bind ?*count-A* (+ ?*count-A* 1)))

(defrule count-grade-B
  (student ? B)
  =>
  (bind ?*count-B* (+ ?*count-B* 1)))

(defrule count-grade-C
  (student ? C)
  =>
  (bind ?*count-C* (+ ?*count-C* 1)))

(defrule show-results
  (declare (salience -1))
  (initial-fact)
  =>
  (printout t "Grade A: " ?*count-A* " students" crlf)
  (printout t "Grade B: " ?*count-B* " students" crlf)
  (printout t "Grade C: " ?*count-C* " students" crlf)
  (printout t "Total:   " (+ ?*count-A* ?*count-B* ?*count-C*) " students" crlf))
```

Виконання:

```
CLIPS> (clear)
CLIPS> (load students.txt)
.........
TRUE
CLIPS> (load grades.clp)
.........
TRUE
CLIPS> (reset)
CLIPS> (run)

=== Exam Results ===
Grade A: 5 students
Grade B: 4 students
Grade C: 3 students
Total:   12 students
```

Програма коректно підрахувала: 5 студентів з оцінкою A (Petrenko, Shevchenko, Lysenko, Moroz, Pavlenko), 4 з оцінкою B (Koval, Tkachuk, Melnyk, Rudenko) та 3 з оцінкою C (Bondar, Savchenko, Marchenko).

Структура програми аналогічна прикладу з конференцією:
- Дані завантажуються з окремого файлу `students.txt` командою `(load)`
- Три правила-лічильники використовують універсальну підстановку `?` для прізвища
- Правило `show-results` з пріоритетом `-1` виконується останнім і виводить підсумки

---

### 3. Висновки

У ході виконання лабораторної роботи вивчено механізм правил у CLIPS:

1. Правила у CLIPS задаються конструктором `defrule` і складаються з лівої частини (умови) та правої частини (дії), розділених символом `=>`.

2. Машина логічного висновку працює циклічно: зіставлення фактів з умовами правил → вибір правила → виконання дій. Правило активізується стільки разів, скільки фактів задовольняють його умову.

3. Пріоритет правил задається функцією `declare` з параметром `salience` (від -10000 до +10000, за замовчуванням 0). Це дозволяє контролювати порядок виконання правил.

4. Глобальні змінні (`defglobal`) зберігають стан між активаціями різних правил. Функція `bind` виконує присвоювання.

5. Розділення даних (файл .txt) і логіки (файл .clp) забезпечує модульність бази знань.
