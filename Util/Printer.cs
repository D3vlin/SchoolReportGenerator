using static System.Console;

namespace SchoolCore.Util
{
    public static class Printer
    {
        public static void DrawTopLine(int length = 10)
        {
            Write("╔".PadRight(length, '═'));
            WriteLine("═╗");
        }
        public static void DrawUnderLine(int length = 10)
        {
            Write("╚".PadRight(length, '═'));
            WriteLine("═╝");
        }

        public static void WriteTitle(string title, bool newLine = false)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (newLine) { WriteLine(""); }
            DrawTopLine(title.Length);
            WriteLine($"║{title}║");
            DrawUnderLine(title.Length);
            WriteLine("");
        }

        public static void WriteOption(string option)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteLine($"╠═ {option}");
        }

        public static void WriteAnswer(string answer)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteLine($"{answer}");
        }

        public static void WriteResult(string result)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteLine($"{result}");
        }

        public static void WriteError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteLine($"{error}");
        }

        public static void PressEnter()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteLine("Presione enter para continuar");
        }

        public static void PressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteLine("\nPresione un tecla para continuar");
            ReadKey();
        }
    }
}