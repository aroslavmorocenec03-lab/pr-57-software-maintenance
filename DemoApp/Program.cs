using System.Text;
using DemoApp;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = new UTF8Encoding(false);
return GreetingDialog.Run(Console.In, Console.Out);
