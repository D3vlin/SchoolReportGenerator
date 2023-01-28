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

        public static void WriteTitle(string title)
        {
            DrawTopLine(title.Length);
            WriteLine($"║{title}║");
            DrawUnderLine(title.Length);
            WriteLine("");
        }

        public static void WriteOption(string option)
        {
            WriteLine($"╠{option}");
        }

        public static void PressEnter()
        {
            WriteLine("Presione enter para continuar");
        }
    }
}