# ПР-57 — Супровід програм

**Ярослав Мороченець.** Навчальний консольний застосунок DemoApp (.NET 10) демонструє супровід ПЗ та підготовку релізів.

- `dev` — основна гілка розробки й default branch.
- `master` — перевірені релізи; зміни лише через Pull Request, з обов’язковими перевірками.
- `release/1.1` — зафіксований кандидат наступного випуску з VERSION.md та CHANGELOG.md.
- Тег `v1.0` — перша стабільна версія (SemVer 1.0.0), яка запитує ім’я й виводить привітання.

Запуск: `dotnet run --project DemoApp/DemoApp.csproj`.
Перевірки: `dotnet run --project DemoApp.Checks/DemoApp.Checks.csproj --configuration Release` або `pwsh scripts/Verify.ps1`.

Статус `local-build-and-tests` публікується після фактичного локального виконання збірки й автоматизованих перевірок на відповідному коміті. Це локальні перевірки, а не GitHub Actions.
