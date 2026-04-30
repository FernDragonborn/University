# Мережевий графік проекту Track List (Mermaid)

## 1. Критичний шлях (виділений)

```mermaid
graph LR
    classDef crit fill:#ff6b6b,stroke:#c0392b,color:#fff,stroke-width:3px
    classDef norm fill:#74b9ff,stroke:#2980b9,color:#fff
    classDef qa fill:#a29bfe,stroke:#6c5ce7,color:#fff

    BE001["BE-001<br/>Project Init<br/>6h | ES:0 EF:6"]:::crit
    BE002["BE-002<br/>Auth Infra JWT<br/>5h | ES:6 EF:11"]:::crit
    BE101["BE-101<br/>Auth Endpoints<br/>10h | ES:11 EF:21"]:::crit
    BE201["BE-201<br/>Profile CRUD<br/>6h | ES:21 EF:27"]:::crit
    BE701["BE-701<br/>User Mgmt API<br/>5h | ES:27 EF:32"]:::crit
    FE701["FE-701<br/>Admin Users Table<br/>6h | ES:32 EF:38"]:::crit
    QA001["QA-001<br/>Smoke Testing<br/>10h | ES:38 EF:48"]:::qa

    BE001 --> BE002 --> BE101 --> BE201 --> BE701 --> FE701 --> QA001
```

**Тривалість критичного шляху: 48 людино-годин**

---

## 2. Повний мережевий графік

```mermaid
graph LR
    classDef crit fill:#ff6b6b,stroke:#c0392b,color:#fff,stroke-width:3px
    classDef be fill:#74b9ff,stroke:#2980b9,color:#fff
    classDef fe fill:#55efc4,stroke:#00b894,color:#333
    classDef infra fill:#ffeaa7,stroke:#fdcb6e,color:#333
    classDef qa fill:#a29bfe,stroke:#6c5ce7,color:#fff

    %% Sprint 0 - Init
    BE001["BE-001<br/>Project Init<br/>6h"]:::crit
    BE002["BE-002<br/>Auth Infra<br/>5h"]:::crit
    BE003["BE-003<br/>Test Setup BE<br/>6h"]:::be
    FE001["FE-001<br/>Project Init FE<br/>6h"]:::fe
    FE002["FE-002<br/>API Client<br/>8h"]:::fe
    FE003["FE-003<br/>Test Setup FE<br/>5h"]:::fe
    DO001["DO-001<br/>Docker<br/>6h"]:::infra

    %% Sprint 1 - Auth
    BE101["BE-101<br/>Auth Endpoints<br/>10h"]:::crit
    FE101["FE-101<br/>Auth Pages<br/>8h"]:::fe
    FE102["FE-102<br/>User Store<br/>4h"]:::fe

    %% Sprint 2 - Search/TMDB
    BE901["BE-901<br/>TMDB Service<br/>10h"]:::be
    BE902["BE-902<br/>Media Cache<br/>8h"]:::be
    BE903["BE-903<br/>Search API<br/>5h"]:::be
    FE901["FE-901<br/>Search UI<br/>6h"]:::fe
    FE902["FE-902<br/>Media Page<br/>6h"]:::fe

    %% Sprint 3 - Profiles
    BE201["BE-201<br/>Profile CRUD<br/>6h"]:::crit
    BE202["BE-202<br/>Follow Logic<br/>5h"]:::be
    FE201["FE-201<br/>Profile Page<br/>6h"]:::fe
    FE202["FE-202<br/>Follow Btn<br/>2h"]:::fe
    FE203["FE-203<br/>Edit Profile<br/>4h"]:::fe

    %% Sprint 4 - Reviews
    BE401["BE-401<br/>Review Entities<br/>5h"]:::be
    BE402["BE-402<br/>Review CRUD<br/>12h"]:::be
    BE501["BE-501<br/>Tracking<br/>4h"]:::be
    FE401["FE-401<br/>Rich Text<br/>8h"]:::fe
    FE402["FE-402<br/>Review UI<br/>6h"]:::fe
    FE501["FE-501<br/>Status Btn<br/>3h"]:::fe

    %% Sprint 5 - Collections
    BE801["BE-801<br/>Collection Entities<br/>6h"]:::be
    BE802["BE-802<br/>Collection CRUD<br/>5h"]:::be
    BE803["BE-803<br/>Sharing API<br/>4h"]:::be
    BE804["BE-804<br/>Collection Items<br/>4h"]:::be
    FE801["FE-801<br/>Collections UI<br/>5h"]:::fe
    FE802["FE-802<br/>Collection Page<br/>5h"]:::fe
    FE803["FE-803<br/>Share Modal<br/>6h"]:::fe
    FE804["FE-804<br/>Add to List<br/>3h"]:::fe

    %% Sprint 6 - Moderation
    BE601["BE-601<br/>Reports<br/>5h"]:::be
    BE602["BE-602<br/>Moderation API<br/>6h"]:::be
    BE603["BE-603<br/>Translation Mod<br/>4h"]:::be
    FE601["FE-601<br/>Report Modal<br/>3h"]:::fe
    FE602["FE-602<br/>Mod Layout<br/>3h"]:::fe
    FE603["FE-603<br/>Reports Queue<br/>5h"]:::fe
    FE604["FE-604<br/>Translation Queue<br/>5h"]:::fe

    %% Sprint 7 - Admin
    BE701["BE-701<br/>User Mgmt API<br/>5h"]:::crit
    BE702["BE-702<br/>Stats + CSV<br/>10h"]:::be
    BE703["BE-703<br/>Media Mgmt<br/>3h"]:::be
    FE701["FE-701<br/>Admin Users<br/>6h"]:::crit
    FE702["FE-702<br/>Stats Dashboard<br/>10h"]:::fe

    %% Sprint 8 - Polish
    BE004["BE-004<br/>Serilog<br/>4h"]:::infra
    BE005["BE-005<br/>Exception Handler<br/>3h"]:::infra
    FE004["FE-004<br/>Error Pages<br/>2h"]:::fe
    QA001["QA-001<br/>Smoke Test<br/>10h"]:::qa
    QA002["QA-002<br/>Perf Test<br/>8h"]:::qa

    %% Dependencies - from BE-001
    BE001 --> BE002
    BE001 --> BE003
    BE001 --> BE901
    BE001 --> BE401
    BE001 --> BE801
    BE001 --> BE601
    BE001 --> BE702

    %% Auth chain
    BE002 --> BE101
    BE101 --> FE101
    BE101 --> BE201

    %% Profile chain
    BE201 --> BE202
    BE201 --> FE201
    BE201 --> BE701
    BE202 --> FE202
    FE201 --> FE203

    %% Admin chain (CRITICAL)
    BE701 --> FE701

    %% TMDB/Search chain
    BE901 --> BE902
    BE902 --> BE903
    BE902 --> FE902
    BE902 --> BE603
    BE902 --> BE703
    BE903 --> FE901

    %% Review chain
    BE401 --> BE402
    BE401 --> BE501
    BE402 --> FE402
    BE501 --> FE501

    %% Collection chain
    BE801 --> BE802
    BE802 --> BE803
    BE802 --> BE804
    BE803 --> FE803
    BE804 --> FE801
    BE804 --> FE802
    BE804 --> FE804

    %% Moderation chain
    BE601 --> BE602
    BE601 --> FE601
    BE602 --> FE603
    BE603 --> FE604

    %% Stats chain
    BE702 --> FE702

    %% FE init
    FE001 --> FE003
    FE002 --> FE102

    %% QA dependencies
    FE101 --> QA001
    FE201 --> QA001
    FE402 --> QA001
    FE801 --> QA001
    FE603 --> QA001
    FE701 --> QA001
    BE101 --> QA002
    BE402 --> QA002
    BE802 --> QA002
```

### Легенда

| Колір         | Значення                    |
| ------------- | --------------------------- |
| 🔴 Червоний   | Критичний шлях (резерв = 0) |
| 🔵 Синій      | Backend задачі              |
| 🟢 Зелений    | Frontend задачі             |
| 🟡 Жовтий     | Інфраструктура              |
| 🟣 Фіолетовий | QA/Тестування               |
