# Лабораторна робота №2

## Структура декомпозиції робіт (WBS). Покерне планування

### 1. Постановка задачі

Метою лабораторної роботи є виконання структурної декомпозиції робіт (WBS) проекту «Track List» по етапах життєвого циклу та по функціоналу, а також проведення оцінки трудомісткості робіт за допомогою покерного планування.

---

### 2. Декомпозиція робіт по етапах життєвого циклу (WBS)

```
Track List
├── Sprint 0: Ініціалізація
│   ├── BE-001: Project Init & Database Setup
│   │   ├── Створити .NET Web API проєкт
│   │   ├── Підключити EF Core + Npgsql (PostgreSQL)
│   │   ├── Реалізувати BaseEntity (Guid v7, CreatedAt, UpdatedAt, DeletedAt)
│   │   ├── Налаштувати Global Query Filter (Soft Delete)
│   │   └── Налаштувати генерацію GUID v7
│   ├── BE-002: Auth Infrastructure (JWT)
│   │   ├── Налаштувати JwtBearer автентифікацію
│   │   ├── Створити TokenService
│   │   └── Створити сутність User
│   ├── BE-003: Test Setup
│   │   └── Створити BDD-тести із feature-файлів (SpecFlow)
│   ├── FE-001: Project Init & Layouts
│   │   ├── Ініціалізувати SvelteKit проєкт
│   │   ├── Налаштувати TailwindCSS v4
│   │   ├── Створити базовий layout (Header, Footer)
│   │   └── Налаштувати аліаси шляхів
│   ├── FE-002: API Client Setup
│   │   ├── Налаштувати Fetch wrapper
│   │   ├── Реалізувати інтерцептори (JWT в заголовки)
│   │   └── Обробка помилок (401 → редирект на логін)
│   ├── FE-003: Test Setup
│   │   └── Створити тести із feature-файлів (Cucumber.js)
│   └── DO-001: Docker
│       └── Написати docker-compose.yml (API + Frontend + PostgreSQL + Nginx)
│
├── Sprint 1: Автентифікація
│   ├── BE-101: Auth Endpoints
│   │   ├── POST /register (валідація, хешування, унікальність)
│   │   └── POST /login (перевірка пароля, видача JWT)
│   ├── FE-101: Auth Pages
│   │   ├── Створити сторінки /login та /register
│   │   ├── Реалізувати форми з клієнтською валідацією
│   │   ├── Інтеграція з BE-101
│   │   └── Збереження токена та редирект
│   └── FE-102: User Store & Route Guard
│       ├── Створити Svelte Store (userStore)
│       └── Реалізувати захист маршрутів у hooks.server.ts
│
├── Sprint 2: Пошук та інтеграція TMDB
│   ├── BE-901: TMDB Integration Service
│   │   ├── Отримати API Key для TMDB
│   │   ├── Створити TmdbService (Search, GetById)
│   │   └── Мапінг зовнішніх даних на внутрішню модель
│   ├── BE-902: Media Entities & Cache Logic
│   │   ├── Створити сутності Media та MediaTranslations
│   │   └── Реалізувати логіку GetOrCreate (БД → API → збереження)
│   ├── BE-903: Search Endpoint
│   │   ├── Пошук по локальній БД
│   │   ├── Пошук по зовнішньому API
│   │   └── Об'єднання результатів
│   ├── FE-901: Global Search Component
│   │   ├── Searchbar з debouncing
│   │   └── Випадаючий список результатів
│   └── FE-902: Media Page (Basic)
│       ├── Сторінка /media/[id]
│       ├── Підтримка GUID та TMDB ID
│       └── Відображення інформації про медіа
│
├── Sprint 3: Профілі та підписки
│   ├── BE-201: Profile CRUD
│   │   ├── GET /api/profiles/{username}
│   │   ├── PUT /api/profiles/me
│   │   └── Завантаження аватарки
│   ├── BE-202: Follow Logic
│   │   ├── Сутність Follow (Soft Delete)
│   │   ├── POST /api/profiles/{username}/follow
│   │   ├── DELETE /api/profiles/{username}/follow
│   │   └── Додати isFollowing у відповідь
│   ├── FE-201: Profile Page
│   │   └── Сторінка /profile/[username] з умовним рендерингом
│   ├── FE-202: Follow Button Component
│   │   └── Stateful-кнопка Follow/Unfollow
│   └── FE-203: Edit Profile Page
│       └── Форма редагування (ім'я, біо, аватар)
│
├── Sprint 4: Рецензії та трекінг
│   ├── BE-401: Review & Comment Entities
│   │   ├── Сутності Review, ReviewLike, Comment (Soft Delete)
│   │   └── Унікальний індекс user+media (BRL-4)
│   ├── BE-402: Review CRUD Endpoints
│   │   ├── POST /api/media/{id}/reviews
│   │   ├── GET /api/media/{id}/reviews
│   │   └── Лайки та коментарі API
│   ├── BE-501: Tracking Logic
│   │   ├── Сутність TrackingStatus (ENUM)
│   │   └── POST /api/tracking (Upsert)
│   ├── FE-401: Rich Text Editor
│   │   └── Інтеграція Tiptap для рецензій
│   ├── FE-402: Review Components
│   │   ├── ReviewList та ReviewItem
│   │   ├── Форма створення рецензії
│   │   └── Інтеграція з BE-402
│   └── FE-501: Status Button
│       ├── Випадаючий список статусів
│       └── Інтеграція з BE-501
│
├── Sprint 5: Колекції
│   ├── BE-801: Collection Entities & Access Service
│   │   ├── Сутності Collection, CollectionItem (Soft Delete)
│   │   ├── Сутність CollectionAccess
│   │   └── ICollectionAccessService (CanView, CanEdit)
│   ├── BE-802: Collection CRUD
│   │   ├── POST /api/collections
│   │   ├── PUT /api/collections/{id}
│   │   └── DELETE /api/collections/{id} (Soft Delete)
│   ├── BE-803: Sharing Endpoints
│   │   ├── POST /api/collections/{id}/access
│   │   ├── DELETE /api/collections/{id}/access/{userId}
│   │   └── GET /api/collections/{id}/access
│   ├── BE-804: Collection Items Logic
│   │   ├── POST /api/collections/{id}/items
│   │   ├── DELETE /api/collections/{id}/items/{itemId}
│   │   └── GET /api/collections/{id}
│   ├── FE-801: Collections Dashboard
│   │   └── Вкладка "Списки" у профілі
│   ├── FE-802: Collection Detail Page
│   │   └── Сторінка /collections/[id]
│   ├── FE-803: Share Modal Component
│   │   └── Модалка з пошуком юзерів та управлінням доступом
│   └── FE-804: "Add to List" Button
│       └── Кнопка додавання медіа до списку
│
├── Sprint 6: Модерація
│   ├── BE-601: Reporting System
│   │   ├── Сутність Report (ENUM: Pending, Resolved...)
│   │   ├── POST /api/reports
│   │   └── Поле ProcessedByUserId
│   ├── BE-602: Moderation Dashboard API
│   │   ├── GET /api/moderation/reports (фільтр Pending)
│   │   ├── POST .../resolve (soft delete контенту)
│   │   └── POST .../dismiss (відхилення)
│   ├── BE-603: Translation Moderation API
│   │   ├── GET /api/moderation/translations (Pending)
│   │   ├── POST .../approve
│   │   └── POST .../reject
│   ├── FE-601: Report Modal
│   │   └── Модалка "Поскаржитись"
│   ├── FE-602: Moderator Layout
│   │   └── Захищений маршрут /moderation
│   ├── FE-603: Reports Queue UI
│   │   └── Таблиця скарг з кнопками дій
│   └── FE-604: Translation Queue UI
│       └── Таблиця перекладів з порівнянням
│
├── Sprint 7: Адміністрування
│   ├── BE-701: User Management API
│   │   ├── GET /api/admin/users (пагінація, пошук)
│   │   ├── POST .../role (зміна ролі)
│   │   └── DELETE .../user (Soft Delete)
│   ├── BE-702: Statistics Aggregation
│   │   ├── GET /api/admin/stats
│   │   ├── SQL-запити COUNT, GROUP BY
│   │   └── Генерація CSV/Excel
│   ├── BE-703: Global Media Management
│   │   ├── PUT /api/admin/translations/{id}
│   │   └── DELETE /api/admin/media/{id}
│   ├── FE-701: Admin Layout & Users
│   │   └── Таблиця юзерів з пошуком та зміною ролей
│   └── FE-702: Statistics Dashboard
│       ├── Графіки (Chart.js)
│       ├── Date Picker для фільтрації
│       └── Кнопка "Завантажити звіт"
│
└── Sprint 8: Полірування та QA
    ├── BE-004: Logging (Serilog)
    │   └── Структурне логування у файл/консоль
    ├── BE-005: Global Exception Handler
    │   └── Middleware для JSON-відповідей на помилки
    ├── FE-004: Error Pages
    │   └── Сторінки 404 та 500
    └── QA-001: Manual Testing
        └── Smoke Test по всіх feature-файлах
```

---

### 3. Функціональна декомпозиція робіт (WBS)

```
Track List
├── Автентифікація (Epic 1)
│   ├── Backend
│   │   ├── BE-002: JWT інфраструктура
│   │   └── BE-101: Auth Endpoints (register, login)
│   └── Frontend
│       ├── FE-101: Сторінки login/register
│       └── FE-102: User Store & Route Guard
│
├── Профіль користувача (Epic 2)
│   ├── Backend
│   │   ├── BE-201: Profile CRUD
│   │   └── BE-202: Follow Logic
│   └── Frontend
│       ├── FE-201: Profile Page
│       ├── FE-202: Follow Button
│       └── FE-203: Edit Profile Page
│
├── Стрічка активності (Epic 3)
│   ├── Backend
│   │   └── FeedController (personal + global feed)
│   └── Frontend
│       └── Feed Page (персональна + глобальна стрічка)
│
├── Медіа-контент та рецензії (Epic 4)
│   ├── Backend
│   │   ├── BE-401: Review & Comment Entities
│   │   └── BE-402: Review CRUD + Likes + Comments
│   └── Frontend
│       ├── FE-401: Rich Text Editor
│       ├── FE-402: Review Components
│       └── FE-902: Media Page
│
├── Трекінг статусів (Epic 5)
│   ├── Backend
│   │   └── BE-501: Tracking (Upsert)
│   └── Frontend
│       └── FE-501: Status Button
│
├── Модерація (Epic 6)
│   ├── Backend
│   │   ├── BE-601: Reporting System
│   │   ├── BE-602: Moderation Dashboard API
│   │   └── BE-603: Translation Moderation API
│   └── Frontend
│       ├── FE-601: Report Modal
│       ├── FE-602: Moderator Layout
│       ├── FE-603: Reports Queue UI
│       └── FE-604: Translation Queue UI
│
├── Адміністрування (Epic 7)
│   ├── Backend
│   │   ├── BE-701: User Management API
│   │   ├── BE-702: Statistics Aggregation
│   │   └── BE-703: Global Media Management
│   └── Frontend
│       ├── FE-701: Admin Layout & Users
│       └── FE-702: Statistics Dashboard
│
├── Колекції (Epic 8)
│   ├── Backend
│   │   ├── BE-801: Collection Entities & Access
│   │   ├── BE-802: Collection CRUD
│   │   ├── BE-803: Sharing Endpoints
│   │   └── BE-804: Collection Items
│   └── Frontend
│       ├── FE-801: Collections Dashboard
│       ├── FE-802: Collection Detail Page
│       ├── FE-803: Share Modal
│       └── FE-804: "Add to List" Button
│
├── Пошук та кешування (Epic 9)
│   ├── Backend
│   │   ├── BE-901: TMDB Integration Service
│   │   ├── BE-902: Media Entities & Cache Logic
│   │   └── BE-903: Search Endpoint
│   └── Frontend
│       └── FE-901: Global Search Component
│
├── Інфраструктура
│   ├── BE-001: Project Init & Database Setup
│   ├── DO-001: Docker (docker-compose)
│   ├── BE-004: Logging (Serilog)
│   └── BE-005: Global Exception Handler
│
└── Тестування та QA
    ├── BE-003: Backend BDD-тести (SpecFlow)
    ├── FE-003: Frontend BDD-тести (Cucumber.js)
    ├── QA-001: Manual Smoke Testing
    └── QA-002: Perfomance testing
```

---

### 4. Таблиця трудомісткості робіт (покерне планування)

Оцінка трудомісткості виконана у людино-годинах. Для кожної роботи наведено три оцінки:

- **О** — оптимістична (мінімальний час за ідеальних умов);
- **Н** — найбільш ймовірна (реалістична оцінка);
- **П** — песимістична (максимальний час з урахуванням ризиків).

Виконавці: **А** — Астаф'єв (TL/DevOps), **П** — Петренко (Frontend), **Пл** — Пилипчук (Backend).

#### Sprint 0: Ініціалізація

Таблиця: Трудомісткість Sprint 0

| ID     | Робота                        | Виконавець | О   | Н   | П   |
| ------ | ----------------------------- | ---------- | --- | --- | --- |
| BE-001 | Project Init & Database Setup | Пл         | 4   | 6   | 10  |
| BE-002 | Auth Infrastructure (JWT)     | Пл         | 3   | 5   | 8   |
| BE-003 | Test Setup (SpecFlow)         | А          | 4   | 6   | 10  |
| FE-001 | Project Init & Layouts        | П          | 4   | 6   | 8   |
| FE-002 | API Client Setup              | П          | 4   | 8   | 12  |
| FE-003 | Test Setup (Cucumber.js)      | А          | 3   | 5   | 8   |

#### Sprint 1: Автентифікація

Таблиця: Трудомісткість Sprint 1

| ID     | Робота                           | Виконавець | О   | Н   | П   |
| ------ | -------------------------------- | ---------- | --- | --- | --- |
| BE-101 | Auth Endpoints (register, login) | Пл         | 6   | 10  | 16  |
| FE-101 | Auth Pages (login, register)     | П          | 6   | 8   | 12  |
| FE-102 | User Store & Route Guard         | П          | 2   | 4   | 6   |
| DO-001 | Docker (docker-compose)          | А          | 4   | 6   | 10  |

#### Sprint 2: Пошук та інтеграція TMDB

Таблиця: Трудомісткість Sprint 2

| ID     | Робота                       | Виконавець | О   | Н   | П   |
| ------ | ---------------------------- | ---------- | --- | --- | --- |
| BE-901 | TMDB Integration Service     | Пл         | 6   | 10  | 16  |
| BE-902 | Media Entities & Cache Logic | Пл         | 4   | 8   | 12  |
| BE-903 | Search Endpoint              | Пл         | 3   | 5   | 8   |
| FE-901 | Global Search Component      | П          | 4   | 6   | 10  |
| FE-902 | Media Page (Basic)           | П          | 4   | 6   | 10  |

#### Sprint 3: Профілі та підписки

Таблиця: Трудомісткість Sprint 3

| ID     | Робота                  | Виконавець | О   | Н   | П   |
| ------ | ----------------------- | ---------- | --- | --- | --- |
| BE-201 | Profile CRUD            | Пл         | 4   | 6   | 10  |
| BE-202 | Follow Logic            | Пл         | 3   | 5   | 8   |
| FE-201 | Profile Page            | П          | 4   | 6   | 10  |
| FE-202 | Follow Button Component | П          | 1   | 2   | 4   |
| FE-203 | Edit Profile Page       | П          | 3   | 4   | 6   |

#### Sprint 4: Рецензії та трекінг

Таблиця: Трудомісткість Sprint 4

| ID     | Робота                         | Виконавець | О   | Н   | П   |
| ------ | ------------------------------ | ---------- | --- | --- | --- |
| BE-401 | Review & Comment Entities      | Пл         | 3   | 5   | 8   |
| BE-402 | Review CRUD + Likes + Comments | Пл         | 8   | 12  | 18  |
| BE-501 | Tracking Logic (Upsert)        | Пл         | 2   | 4   | 6   |
| FE-401 | Rich Text Editor (Tiptap)      | П          | 4   | 8   | 14  |
| FE-402 | Review Components              | П          | 4   | 6   | 10  |
| FE-501 | Status Button                  | П          | 2   | 3   | 5   |

#### Sprint 5: Колекції

Таблиця: Трудомісткість Sprint 5

| ID     | Робота                               | Виконавець | О   | Н   | П   |
| ------ | ------------------------------------ | ---------- | --- | --- | --- |
| BE-801 | Collection Entities & Access Service | Пл         | 4   | 6   | 10  |
| BE-802 | Collection CRUD                      | Пл         | 3   | 5   | 8   |
| BE-803 | Sharing Endpoints                    | Пл         | 2   | 4   | 6   |
| BE-804 | Collection Items Logic               | Пл         | 2   | 4   | 6   |
| FE-801 | Collections Dashboard                | П          | 3   | 5   | 8   |
| FE-802 | Collection Detail Page               | П          | 3   | 5   | 8   |
| FE-803 | Share Modal Component                | П          | 4   | 6   | 10  |
| FE-804 | "Add to List" Button                 | П          | 2   | 3   | 5   |

#### Sprint 6: Модерація

Таблиця: Трудомісткість Sprint 6

| ID     | Робота                     | Виконавець | О   | Н   | П   |
| ------ | -------------------------- | ---------- | --- | --- | --- |
| BE-601 | Reporting System           | Пл         | 3   | 5   | 8   |
| BE-602 | Moderation Dashboard API   | Пл         | 4   | 6   | 10  |
| BE-603 | Translation Moderation API | Пл         | 2   | 4   | 6   |
| FE-601 | Report Modal               | П          | 2   | 3   | 5   |
| FE-602 | Moderator Layout           | П          | 2   | 3   | 5   |
| FE-603 | Reports Queue UI           | П          | 3   | 5   | 8   |
| FE-604 | Translation Queue UI       | П          | 3   | 5   | 8   |

#### Sprint 7: Адміністрування

Таблиця: Трудомісткість Sprint 7

| ID     | Робота                          | Виконавець | О   | Н   | П   |
| ------ | ------------------------------- | ---------- | --- | --- | --- |
| BE-701 | User Management API             | Пл         | 3   | 5   | 8   |
| BE-702 | Statistics Aggregation + CSV    | Пл         | 6   | 10  | 16  |
| BE-703 | Global Media Management         | Пл         | 2   | 3   | 5   |
| FE-701 | Admin Layout & Users Table      | П          | 4   | 6   | 10  |
| FE-702 | Statistics Dashboard (Chart.js) | П          | 6   | 10  | 16  |

#### Sprint 8: Полірування та QA

Таблиця: Трудомісткість Sprint 8

| ID     | Робота                   | Виконавець | О   | Н   | П   |
| ------ | ------------------------ | ---------- | --- | --- | --- |
| BE-004 | Logging (Serilog)        | А          | 2   | 4   | 6   |
| BE-005 | Global Exception Handler | А          | 2   | 3   | 5   |
| FE-004 | Error Pages (404, 500)   | П          | 1   | 2   | 4   |
| QA-001 | Manual Smoke Testing     | А          | 6   | 10  | 16  |
| QA-002 | Perfomance testing       | А          | 6   | 8   | 12  |

#### Зведена таблиця по спринтах

Таблиця: Зведена трудомісткість по спринтах

| Спринт    | О (год) | Н (год) | П (год) |
| --------- | ------- | ------- | ------- |
| Sprint 0  | 23      | 36      | 58      |
| Sprint 1  | 14      | 22      | 34      |
| Sprint 2  | 21      | 35      | 56      |
| Sprint 3  | 15      | 23      | 38      |
| Sprint 4  | 23      | 38      | 61      |
| Sprint 5  | 23      | 38      | 61      |
| Sprint 6  | 19      | 31      | 50      |
| Sprint 7  | 21      | 34      | 55      |
| Sprint 8  | 17      | 27      | 43      |
| **Разом** | **176** | **284** | **456** |

---

### 5. Висновки

У ході виконання лабораторної роботи побудовано два види структурної декомпозиції робіт (WBS) для проекту «Track List»:

1. **WBS по етапах життєвого циклу** — декомпозиція по 9 спринтах (Sprint 0–8), де кожен спринт відповідає окремій фазі waterfall-підходу. Виділено 48 робіт нижнього рівня, розподілених між Backend (23 задачі), Frontend (22 задачі) та інфраструктурою/QA (3 задачі).

2. **Функціональна WBS** — декомпозиція по 9 епіках (функціональних областях) з окремими гілками для інфраструктури та тестування. Кожен епік розділено на Backend та Frontend підзадачі.

3. **Покерне планування** — для кожної з 48 робіт нижнього рівня проведено трипараметричну оцінку трудомісткості (оптимістична, найбільш ймовірна, песимістична). Загальна трудомісткість проекту оцінена в діапазоні від 170 до 444 людино-годин, з найбільш ймовірним значенням 276 людино-годин. Найбільш трудомісткими є Sprint 4 (рецензії) та Sprint 5 (колекції) — по 38 людино-годин у найбільш ймовірному варіанті.
