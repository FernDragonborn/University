---
marp: true
theme: default
paginate: true
size: 16:9
style: |
  section {
    font-family: 'Segoe UI', sans-serif;
    font-size: 22px;
  }
  h1 { color: #2c3e50; font-size: 36px; }
  h2 { color: #34495e; font-size: 30px; border-bottom: 2px solid #3498db; padding-bottom: 4px; }
  table { font-size: 18px; margin: 0 auto; }
  th { background: #3498db; color: white; }
  .pass { color: #27ae60; font-weight: bold; }
  .fail { color: #e74c3c; font-weight: bold; }
  strong { color: #2980b9; }
  footer { font-size: 14px; color: #95a5a6; }
---

# Тестування продуктивності застосунку Track List

**Курсовий проєкт з ТВПЗ (КП)**

Студент: Астаф'єв А. Г., група 642п
Керівник: Клименко Т. А.

ХАІ, 2026

---

## Мета та стандарт якості

**Мета:** оцінити характеристики якості Track List за **ISO/IEC 25010 — Performance Efficiency**

| Підхарактеристика | Що вимірюємо |
|---|---|
| **Time behaviour** | Час відгуку API (p50, p95, p99) |
| **Resource utilization** | CPU, RAM, GC Heap, ThreadPool |
| **Capacity** | Max VUs без помилок, req/s |

**Об'єкт:** REST API (ASP.NET Core + PostgreSQL), 15 ендпоінтів

---

## Інструменти

| Компонент | Інструмент | Призначення |
|---|---|---|
| Навантаження | **k6** (Go runtime) | Генерація VUs, thresholds, HTML-звіти |
| Серверні метрики | **dotnet-counters** | CPU, RAM, GC, ThreadPool у реальному часі |
| Середовище | **Docker Compose** | Ізольоване тестове оточення |
| Reverse proxy | **Caddy** | Наближення до продуктивної архітектури |

**Тестове середовище:** Windows 10 / WSL2, 6 CPU, 8 GB RAM
**API:** 4 CPU, 2 GB RAM | **PostgreSQL:** 2 CPU, 4 GB RAM

---

## Сценарії тестування

| Сценарій | VUs | Тривалість | Мета |
|---|---|---|---|
| **Smoke** | 2 | 1 хв | Базова працездатність |
| **Load** | 50 (30+15+5) | 5 хв | Типове навантаження за ролями |
| **Stress** | 10 → 200 | 10 хв | Пошук точки деградації |
| **Ultra-Stress** | 50 → 1000 | 15 хв | Абсолютна межа системи |

**Критерії прийняття (thresholds):**

| Сценарій | p(95) | p(99) | Error rate |
|---|---|---|---|
| Smoke | < 300 мс | < 500 мс | < 1% |
| Load | < 300 мс | < 1000 мс | < 5% |
| Stress | < 300 мс | < 2000 мс | < 10% |
| Ultra-Stress | < 1000 мс | < 5000 мс | < 20% |

---

## Зведені результати

| Сценарій | Запитів | Req/s | p(95), мс | Max, мс | Помилки | Статус |
|---|---|---|---|---|---|---|
| Smoke (2 VUs) | 778 | 13,3 | **143** | 654 | 0% | **PASS** |
| Load (50 VUs) | 16 162 | 56,4 | **154** | 1 424 | 0% | **PASS** |
| Stress (200 VUs) | 85 100 | 149,9 | **100** | 919 | 0% | **PASS** |
| Ultra (1000 VUs) | 440 889 | 527,2 | **3 240** | 5 752 | 0% | **PARTIAL FAIL** |

- Smoke/Load/Stress: усі пороги дотримані, **0% помилок**
- Ultra-Stress: p(95) = 3240 мс > 1000 мс, але **0% помилок** навіть при 1000 VUs
- Пропускна здатність: 13,3 → 527,2 req/s (×40)

---

## Серверні метрики (dotnet-counters)

| Сценарій | CPU avg | CPU max | RAM max, МБ | GC Heap max, МБ | Queue max |
|---|---|---|---|---|---|
| Smoke | 11,6% | 20,8% | 249 | 36 | 0 |
| Load | 27,8% | 80,2% | 301 | 89 | 16 |
| Stress | 21,6% | 46,5% | 280 | 79 | 4 |
| Ultra | 45,5% | 54,7% | 804 | 521 | **188** |

- CPU **не bottleneck** — навіть при 1000 VUs avg лише 45,5%
- **ThreadPool Queue** — головний індикатор деградації: 0 → 188
- GC Heap: 36 → 521 МБ, Server GC пилкоподібний патерн
- Після завершення навантаження — повне відновлення (memory leak відсутній)

---

## Аналіз деградації

| VUs | p(50), мс | p(95), мс | ThreadPool Queue | Характер |
|---|---|---|---|---|
| 2 | 16,9 | 143 | 0 | Стабільно |
| 50 | 19,4 | 154 | 16 | Стабільно |
| 200 | 4,1 | 100 | 4 | Стабільно |
| 1000 | 281,0 | **3 240** | **188** | Деградація |

**Точка перегину:** між 200 та 1000 VUs

- При 200 VUs — p(50) = 4,1 мс (прогрітий кеш PostgreSQL)
- При 1000 VUs — p(50) = 281 мс (×68), p(95) = 3240 мс (×32)
- ThreadPool Queue: 4 → 188 — кореляція з латентністю
- CPU: 21,6% → 45,5% — НЕ обчислювальний bottleneck

![bg right:40% w:480](perf%20tests%20results/degradation_chart.png)

---

## Аналіз по ендпоінтах

| Ендпоінт | 2 VUs, мс | 50 VUs, мс | 200 VUs, мс | 1000 VUs, мс |
|---|---|---|---|---|
| auth_login | 141 | 154 | — | — |
| media_search | 108 | 106 | 89 | **1 543** |
| feed_global | 64 | 10 | 4 | 238 |
| collections_public | 16 | 27 | 4 | 237 |
| feed_personal | 3 | 3 | 3 | 151 |

**Висновки:**
- `media_search` — найповільніший на всіх рівнях (TMDB API)
- `feed_global` прискорюється з навантаженням: 64 → 4 мс (warm cache)
- При 1000 VUs деградація нерівномірна: `media_search` ×35, внутрішні ×80

---

## Bottlenecks та рекомендації

**Виявлені вузькі місця:**

| Bottleneck | Де проявляється | Причина |
|---|---|---|
| TMDB API rate limit | ≤ 200 VUs | Зовнішня залежність, кешування вже є |
| ThreadPool saturation | 1000 VUs | Queue 188, I/O-bound, не CPU-bound |
| GC pressure | 1000 VUs | Heap 521 МБ, Working Set 804 МБ |

**Рекомендації:**
1. Збільшити `MinThreads` у ThreadPool для зменшення черги
2. Оптимізувати GC через `GCLatencyMode` та зменшення алокацій
3. Повторне тестування на продуктивному сервері

---

## Висновки

REST API Track List **відповідає вимогам ISO/IEC 25010 Performance Efficiency** при робочому навантаженні

| Критерій | Результат |
|---|---|
| Time behaviour | p(95) ≤ 154 мс при 50 VUs, ≤ 100 мс при 200 VUs |
| Resource utilization | CPU 27,8%, RAM 261 МБ / 2 ГБ при 50 VUs |
| Capacity | 527,2 req/s при 1000 VUs, 0% помилок |
| Стабільність | 0% помилок на всіх рівнях навантаження |
| Відновлюваність | Повне відновлення метрик після зняття навантаження |

**3 з 4 сценаріїв — PASS, ultra-stress — PARTIAL FAIL** (очікувано при 5× робочому навантаженні)

---

<!-- _class: lead -->

# Дякую за увагу!

**Питання?**
