# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository Purpose

This is a university course project repository for **ТВПЗ (КП)** — "Тестування та верифікація програмного забезпечення" (Software Testing and Verification), a course at ХАІ (Kharkiv Aviation Institute). The completed project becomes **Chapter 3** of the student's bachelor's thesis.

There is no source code here — the repository contains only documentation, assignments, and methodical materials in Ukrainian.

## Primary Reference

**`методичні матеріали/Методичка ТВПЗ(КП) - 2026.pdf`** — 88-page course guide by Клименко Т.А. and Манжос Ю.С. This is the authoritative reference for all templates, examples, and requirements. Read it before generating any artifacts.

## Course Structure

The project consists of 8 practical works divided into two phases:

### Phase 1 — Planning (Practical Works 1–4)
All use MS Word + MS Visio. Each produces a test plan report:
1. **ПР1** — Acceptance test planning (приймальне тестування), 4h self-study
2. **ПР2** — System test planning (системне тестування), 3h self-study
3. **ПР3** — Integration test planning (інтеграційне тестування), 3h self-study
4. **ПР4** — Unit/module test planning (автономне/модульне тестування), 3h self-study

### Phase 2 — Execution (Practical Works 5–8)
Each produces test execution results in table form with conclusions:
5. **ПР5** — Unit testing execution (NUnit/CppUnit/JUnit/PHPUnit + MS VS), 3h
6. **ПР6** — Integration testing execution (+ moq, Cucumber, Selenium), 3h
7. **ПР7** — System testing execution (+ moq, Cucumber, Selenium), 3h
8. **ПР8** — Acceptance/validation testing execution (Cucumber, Selenium), 3h

## Key Artifacts to Produce

- **SRS** — Software Requirements Specification (functional + non-functional requirements)
- **RTM** — Requirements Traceability Matrix (FR/NFR → Test Cases)
- **RTMI** — RTM for integration (components/modules → tests)
- **TestScript / TestCase tables** — structured per ISO/IEC 25010 quality characteristics
- **Test Execution Reports** — actual vs expected results, pass/fail status
- **Acceptance Test Report** — final validation summary

## Quality Model

All testing is framed around **ISO/IEC 25010** — 8 product quality characteristics:
Функціональна придатність, Надійність, Захищеність, Практичність, Ефективність виконання, Супроводжуваність, Переносність, Сумісність.

## Document Requirements

- Total document: **30–35 pages** (not counting appendices)
- Language: Ukrainian
- Format: per ХАІ formatting standards (see `завдання/оформлення пояснювальної записки`)
- Tools: MS Word for documents, MS Visio for diagrams

## Assignments Directory

`завдання/1` through `завдання/8` contain the task descriptions for each practical work (plain text files, no extension).
