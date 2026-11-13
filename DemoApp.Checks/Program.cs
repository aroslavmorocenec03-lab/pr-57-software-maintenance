using DemoApp;

int passed = 0, failed = 0;
void Check(string title, string data, int exit, string[] expected, string[]? forbidden = null)
{
    using var reader = new StringReader(data);
    using var writer = new StringWriter();
    int actualExit = GreetingDialog.Run(reader, writer);
    string actual = writer.ToString();
    bool ok = actualExit == exit && expected.All(actual.Contains)
        && (forbidden is null || forbidden.All(x => !actual.Contains(x)));
    Console.WriteLine($"{(ok ? "PASS" : "FAIL")}: {title}");
    if (ok) passed++;
    else { failed++; Console.WriteLine(actual); }
}

Check("Adult boundary at 18", "Ярослав\n18\n", 0,
    ["Вітаю Ярослав!", "Ім’я: Ярослав. Вік: 18.", "Статус: повнолітня особа."], ["неповнолітня"]);
Check("Underage boundary at 17", "Ярослав\n17\n", 0,
    ["Вік: 17.", "Статус: неповнолітня особа."]);
Check("Zero age is accepted", "Ярослав\n0\n", 0, ["Вік: 0.", "неповнолітня"]);
Check("Upper age limit", "Ярослав\n130\n", 0, ["Вік: 130.", "повнолітня"]);
Check("Negative age is rejected", "Ярослав\n-1\n18\n", 0,
    ["Вік має бути цілим числом від 0 до 130.", "Вік: 18."]);
Check("Non-numeric age is rejected", "Ярослав\nabc\n25\n", 0,
    ["Вік має бути цілим числом від 0 до 130.", "Вік: 25."]);
Check("Empty age is rejected", "Ярослав\n\n17\n", 0,
    ["Вік має бути цілим числом від 0 до 130.", "Вік: 17."]);
Check("Age above range is rejected", "Ярослав\n131\n20\n", 0,
    ["Вік має бути цілим числом від 0 до 130.", "Вік: 20."]);
Check("Trims surrounding name spaces", "  Ярослав  \n21\n", 0, ["Вітаю Ярослав!", "Вік: 21."]);
Check("Empty name then valid input", "\nЯрослав\n18\n", 0,
    ["Ім’я не може бути порожнім.", "Вітаю Ярослав!"]);
Check("EOF before name", "", 1, ["Введення перервано."]);
Check("EOF before age", "Ярослав\n", 1, ["Введення перервано."]);
Console.WriteLine($"Result: {passed} passed, {failed} failed");
return failed == 0 ? 0 : 1;
