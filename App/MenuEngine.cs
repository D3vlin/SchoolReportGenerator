using SchoolCore.Util;
using SchoolCore.Entities;

namespace SchoolCore.App
{
    public static class MenuEngine
    {
        public static Dictionary<string, string> MenuOptions = new Dictionary<string, string>();

        public static string exitOption { get; private set; } = "";

        private static void LoadMenuOptionsDictionary()
        {
            if (MenuOptions.Count() == 0)
            {
                MenuOptions.Add("1", "1. Estado de la escuela");
                MenuOptions.Add("2", "2. Listar asignaturas");
                MenuOptions.Add("3", "3. Listar notas");
                MenuOptions.Add("4", "4. Listar promedio");
                MenuOptions.Add("5", "5. Salir");

                exitOption = "5";
            }
        }

        private static void PrintMenuOptions()
        {
            LoadMenuOptionsDictionary();
            Printer.WriteTitle("Bienvenido al generador del reporte escolar");
            foreach (var option in MenuOptions)
                Printer.WriteOption(option.Value);
        }

        public static string PrintAndSelectMenuOptions()
        {
            Console.Clear();
            PrintMenuOptions();
            Console.WriteLine("\n↓ Ingrese una opción del menu ↓");
            return Console.ReadLine() ?? "";
        }

        public static bool ValidateMenuOption(string option)
        {
            if (!MenuOptions.ContainsKey(option))
            {
              PrintInvalidOption();
              return false;
            }

            return true;
        }

        public static bool IsExitOption(string option)
        {
            return option == exitOption;
        }

        public static void PrintOption(string option)
        {
            Console.Clear();
            Printer.WriteOption(MenuOptions[option]);
            Console.WriteLine("");
        }

        public static bool RepeatMenu()
        {
            string option;
            do
            {
                Console.Clear();
                Printer.WriteTitle("¿Desea repetir el menu?", true);
                Printer.WriteOption("1. SI");
                Printer.WriteOption("2. NO");
                Console.WriteLine("\n↓ Ingrese una opción ↓");
                option = Console.ReadLine() ?? "";

                if (option != "1" && option != "2")
                    PrintInvalidOption();

            } while (option != "1" && option != "2");

            return option == "1";
        }

        private static void PrintInvalidOption()
        {
            Console.WriteLine("\n→ Debe ingresar una opcion del menu,\nPresiones una tecla para continuar...");
            Console.ReadKey();
        }
    }
}