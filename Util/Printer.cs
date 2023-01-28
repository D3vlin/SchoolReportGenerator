using static System.Console;

namespace SchoolCore.Util
{
    public static class Printer
    {
        public static void DrawLine(int length = 10)
        {
            WriteLine("".PadLeft(length, '='));
        }

        public static void WriteTitle(string title)
        {
            DrawLine();
            WriteLine(title);
            DrawLine();
        }

        public static void PressEnter()
        {
            WriteLine("Presione enter para continuar");
        }
    }
}