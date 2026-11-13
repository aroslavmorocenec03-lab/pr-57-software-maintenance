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

Check("Ukrainian name greeting", "Ярослав\n", 0, ["Вітаю Ярослав!"]);
Check("Trims surrounding spaces", "  Ярослав  \n", 0, ["Вітаю Ярослав!"]);
Check("Rejects blank name then accepts next", "  \nЯрослав\n", 0,
    ["Ім’я не може бути порожнім.", "Вітаю Ярослав!"]);
Check("EOF before name", "", 1, ["Введення перервано."]);
Check("EOF after invalid name", "  \n", 1,
    ["Ім’я не може бути порожнім.", "Введення перервано."]);
Console.WriteLine($"Result: {passed} passed, {failed} failed");
return failed == 0 ? 0 : 1;
