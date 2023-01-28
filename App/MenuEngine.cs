using SchoolCore.Util;

namespace SchoolCore.App
{
    public static class MenuEngine
    {
          public static void PrintMenuOptions()             
          {
            Console.Clear();
            Printer.WriteTitle("Bienvenido al generador del reporte escolar");
            Printer.WriteOption("1-Listar alumnos");
            Printer.WriteOption("2-Listar asignaturas");
            Printer.WriteOption("3-Listar notas");
            Printer.WriteOption("4-Listar promedio");
            Printer.WriteOption("5-Salir");

            Console.WriteLine("\n↓Ingrese una opción de menu↓");
          }
    }
}