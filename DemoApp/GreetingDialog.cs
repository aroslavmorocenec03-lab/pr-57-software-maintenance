using System.Globalization;

namespace DemoApp;

public static class GreetingDialog
{
    public static int Run(TextReader input, TextWriter output)
    {
        string name;
        while (true)
        {
            output.Write("Введіть ваше ім’я: ");
            string? line = input.ReadLine();
            if (line is null) return Cancel(output);
            name = line.Trim();
            if (name.Length > 0) break;
            output.WriteLine("Ім’я не може бути порожнім.");
        }

        int age;
        while (true)
        {
            output.Write("Введіть ваш вік: ");
            string? line = input.ReadLine();
            if (line is null) return Cancel(output);
            if (int.TryParse(line.Trim(), NumberStyles.Integer,
                    CultureInfo.InvariantCulture, out age) && age >= 0 && age <= 130)
                break;
            output.WriteLine("Вік має бути цілим числом від 0 до 130.");
        }

        output.WriteLine($"Вітаю {name}!");
        output.WriteLine($"Ім’я: {name}. Вік: {age}.");
        output.WriteLine(age >= 18 ? "Статус: повнолітня особа." : "Статус: неповнолітня особа.");
        return 0;
    }

    private static int Cancel(TextWriter output)
    {
        output.WriteLine("Введення перервано.");
        return 1;
    }
}
