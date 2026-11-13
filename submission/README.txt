ПР-57. Супровід програм
Виконав: Ярослав Мороченець

Репозиторій: https://github.com/aroslavmorocenec03-lab/pr-57-software-maintenance
Pull Request релізу 1.0: https://github.com/aroslavmorocenec03-lab/pr-57-software-maintenance/pull/1

Звіт.docx — опис виконаних етапів, скриншоти та відповіді на всі п’ять запитань.
source/v1.0 — вихідний код першого стабільного випуску, тег v1.0 у master.
source/release-1.1 — підготовлений кандидат 1.1.0-rc.1, включно з VERSION.md і CHANGELOG.md.
programs — готові програми Windows x64. Потрібен .NET Runtime 10 x64.
Для запуску відкрийте Запустити.cmd у відповідній папці programs.
Для збірки та перевірок джерел потрібен .NET SDK 10:
  dotnet run --project DemoApp/DemoApp.csproj
  dotnet run --project DemoApp.Checks/DemoApp.Checks.csproj --configuration Release
Команди виконуйте з папки потрібної версії в source.

Результат перевірок: v1.0 — 5/5; кандидат 1.1 — 12/12.
Вік — ціле число 0–130; повноліття від 18. Межа 130 є навчальним правилом.
Перевірки виконані локально. Це не GitHub Actions.
Стабільний master захищено: лише Pull Request, успішний local-build-and-tests,
застосування правила також до адміністратора, без force push і видалення.
Default branch — dev. Версію 1.1 ще не зливано в master, як і передбачено умовою.

screenshots — справжні знімки порталу GitHub, evidence — протоколи виконання.
PostMaintenance.bundle — історія Git коду й гілок на момент підготовки звіту.
Відновлення: git clone PostMaintenance.bundle restored-repository
