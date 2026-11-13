namespace DemoApp;

public static class GreetingDialog
{
    public static int Run(TextReader input, TextWriter output)
    {
        while (true)
        {
            output.Write("Введіть ваше ім’я: ");
            string? name = input.ReadLine();
            if (name is null)
            {
                output.WriteLine("Введення перервано.");
                return 1;
            }
            name = name.Trim();
            if (name.Length == 0)
            {
                output.WriteLine("Ім’я не може бути порожнім.");
                continue;
            }
            output.WriteLine($"Вітаю {name}!");
            return 0;
        }
    }
}
