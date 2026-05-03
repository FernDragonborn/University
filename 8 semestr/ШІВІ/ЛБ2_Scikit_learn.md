# Лабораторна робота №2

## Рішення завдань інтелектуального аналізу засобами Python

### 1. Мета роботи

Ознайомитися з пакетом Scikit-learn Python. Вивчити основні команди, що застосовуються для попередньої обробки навчальних даних, навчання класифікатора/регресора та аналізу ефективності моделі.

---

### 2. Постановка завдання

**Варіант 2.**

- **Набір даних:** Набір даних: World Happiness Report 2005-2025 Panel Data
  
  https://www.kaggle.com/datasets/elvisbui/world-happiness-report-2005-2025-panel)

- **Модель:** Ridge Regression (Гребенева регресія).

- **Цільова змінна:** Life Ladder (Рівень щастя).

**Завдання згідно з методичними вказівками:**

1. Вивчити призначення пакету Scikit-learn Python.
2. Завантажити дані з файлу, відповідно до варіанту.
3. Відобразити перші декілька рядків даних (head).
4. Вивести інформацію про дані в наборі (info(), describe()).
5. Виконати завдання для свого варіанту (попередня обробка, навчання регресора та аналіз ефективності).

---

### 3. Хід роботи

#### 3.1. Завдання 1–2. Імпорт бібліотек та завантаження даних

Оскільки мета роботи зосереджена на інструментах `Scikit-learn`, імпортуємо виключно модулі для обробки даних, побудови моделі та оцінки метрик.

```python
from typing import cast
import os
import pandas as pd
import kagglehub

path = kagglehub.dataset_download("elvisbui/world-happiness-report-2005-2025-panel")
print("Path to dataset files:", path)

csv_files = [f for f in os.listdir(path) if f.endswith('.csv')]
full_file_path = os.path.join(path, csv_files[0])
df: pd.DataFrame = cast(pd.DataFrame, pd.read_csv(full_file_path))
df.columns = df.columns.str.strip()
```

#### 3.2. Завдання 3–4. Відображення перших рядків та статистики

```python
print("Перші 5 рядків набору даних:")
print(df.head().T.to_string())

print("\nІнформація про структуру даних:")
df.info()

print("\nСтатистичний опис числових ознак:")
print(df.describe().T.to_string())
```

Рисунок: print(df.head().T.to_string())

![](C:\Users\fern\AppData\Roaming\marktext\images\2026-05-03-00-56-54-image.png)

Рисунок: df.info()

![](C:\Users\fern\AppData\Roaming\marktext\images\2026-05-03-00-57-05-image.png)

Рисунок: df.describe().T.to_string()

![](C:\Users\fern\AppData\Roaming\marktext\images\2026-05-03-00-57-13-image.png)

*Висновок з опису:* У наборі даних присутні пропущені значення (NaN), оскільки не всі країни проводили опитування щороку. Відповідно до мети роботи, перед навчанням регресора ці пропуски будуть оброблені засобами `Scikit-learn`.

#### 3.3. Завдання 5. Попередня обробка (Preprocessing) та навчання моделі

Для виконання вимог попередньої обробки використаємо `SimpleImputer` (заповнення пропусків) та `MinMaxScaler` (масштабування).

```python
from sklearn.model_selection import train_test_split
from sklearn.impute import SimpleImputer
from sklearn.preprocessing import MinMaxScaler
from sklearn.linear_model import Ridge
from sklearn.metrics import r2_score

feature_cols = [
    'year',
    'explained_log_gdp_per_capita',
    'explained_social_support',
    'explained_healthy_life_expectancy',
    'explained_freedom',
    'explained_generosity',
    'explained_corruption'
]
target_col = 'happiness_score'

X = df[feature_cols]
y = df[target_col]
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.3, random_state=0)

imputer = SimpleImputer(strategy='median')
X_train_imp = imputer.fit_transform(X_train)
X_test_imp = imputer.transform(X_test)
y_train = y_train.fillna(y_train.median())
y_test = y_test.fillna(y_test.median())

scaler = MinMaxScaler()
X_train_scaled = scaler.fit_transform(X_train_imp)
X_test_scaled = scaler.transform(X_test_imp)

ridge_model = Ridge(alpha=1.0)
ridge_model.fit(X_train_scaled, y_train)

y_pred = ridge_model.predict(X_test_scaled)
r2 = r2_score(y_test, y_pred)

print('Regression R^2 score on training set: {:.2f}'.format(ridge_model.score(X_train_scaled, y_train)))
print('Regression R^2 score on test set: {:.2f}'.format(r2))
```

Рисунок: Результати прогнозування моделі Ridge: залежність передбаченого рівня щастя від фактичного.

![](C:\Users\fern\AppData\Roaming\marktext\images\2026-05-03-00-58-14-image.png)

#### 3.4. Візуалізація результатів навчання (Matplotlib)

Візуалізація якості передбачення регресора за допомогою `matplotlib.pyplot.scatter`, як показано в прикладі до методичних вказівок.

```python
from matplotlib import pyplot as plt

ax = plt.figure(figsize=(8, 6)).add_subplot()

ax.scatter(y_test, y_pred, color='#fceaa2', alpha=0.5, edgecolors='#383630')
ax.plot([y_test.min(), y_test.max()], [y_test.min(), y_test.max()], 'g--', lw=2)

ax.set_title('Ridge Regression Results')
ax.set_xlabel('Actual Happiness Score')
ax.set_ylabel('Predicted Happiness Score')
plt.show()
```

Рисунок: візуалізація результатів навчання

![](C:\Users\fern\AppData\Roaming\marktext\images\2026-05-03-00-59-05-image.png)

---

### 4. Висновки

У ході виконання лабораторної роботи було повністю досягнуто її мету:

1. Опрацьовано принципи використання бібліотеки **Scikit-learn** для вирішення задачі контрольованого навчання на реальному наборі даних.

2. Вивчено та застосовано основні команди попередньої обробки: за допомогою класу `SimpleImputer` вирішено проблему пропущених даних, а через `StandardScaler` нормалізовано ознаки, що є обов'язковим кроком для коректної оптимізації моделі Ridge.

3. Проведено навчання регресора **Ridge**, який на основі показників ВВП, соціальної підтримки та інших ознак навчився прогнозувати цільовий показник.

4. Здійснено аналіз ефективності за допомогою метрики `R2 score` (коефіцієнт детермінації), що підтвердило здатність моделі узагальнювати дані на тестовій вибірці.
