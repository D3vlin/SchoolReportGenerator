// See https://aka.ms/new-console-template for more information
using static System.Console;
using SchoolCore.Entities;
using SchoolCore.Util;
using SchoolCore.App;

internal class Program
{
    private static void Main(string[] args)
    {
        #region EventHandler
        AppDomain root = AppDomain.CurrentDomain;
        root.AssemblyLoad += Load;
        root.ProcessExit += Exit;
        #endregion

        #region Main
        var schoolEngine = new SchoolEngine();
        schoolEngine.Initialize();

        var schoolObjecs = schoolEngine.GetSchoolObjects(
            out int evaluationsCounter,
            out int studentsCounter,
            out int asignaturesCounter,
            out int coursesCounter
        );

        var IPlaceList = from obj in schoolObjecs
                         where obj is IPlace
                         select (IPlace)obj;

        var schoolDictionary = schoolEngine.GetObjectDictionary();

#pragma warning disable CS0168
        string option;
        string exitOption;
#pragma warning restore CS0168
        do
        {
            option = MenuEngine.PrintAndSelectMenuOptions();

            if (MenuEngine.ValidateMenuOption(option) && !MenuEngine.IsExitOption(option))
            {
                MenuEngine.PrintOption(option);
                switch (option)
                {
                    case "1":
                        schoolEngine.PrintSchoolStatus(schoolDictionary);
                        break;

                    case "2":
                        schoolEngine.PrintAllCourses(schoolDictionary);
                        break;

                    case "3":
                        schoolEngine.PrintAllAsignatures(schoolDictionary);
                        break;

                    case "4":
                        schoolEngine.PrintAllStudents(schoolDictionary);
                        break;

                    case "5":
                        schoolEngine.PrintDictionary(schoolDictionary, true);
                        break;
                }
            }

            if (!MenuEngine.IsExitOption(option) && !MenuEngine.RepeatMenu())
                option = MenuEngine.exitOption;

        } while (!MenuEngine.IsExitOption(option));
        #endregion

        schoolEngine.school.CleanAddress();

        Printer.WriteTitle("Reporteador");
        var reporter = new Reporter(schoolDictionary);
        var evaluationList = reporter.GetEvaluationList();
        var asignatureList = reporter.GetAsignatureList();
        var evaluationXAsignature = reporter.GetDictionaryEvaluationXAsignature();
        var promStudentXAsignature = reporter.GetPromStudentXAsignature();

        Printer.WriteTitle("Ingreso");
        var newEvaluation = new Evaluation();
        string name, stringNote;

        WriteLine("Ingrese nombre de evaluacion");
        Printer.PressEnter();
        name = ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Nombre no puede seer vacio");
        }
        {
            newEvaluation.Name = name.ToLower();
            WriteLine("Ingreso correcto");
        }

        WriteLine("Ingrese nota de evaluacion");
        Printer.PressEnter();
        stringNote = ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(stringNote))
        {
            throw new ArgumentException("Nota no puede seer vacio");
        }
        else
        {
            try
            {
                newEvaluation.Note = float.Parse(stringNote);

                if (newEvaluation.Note < 0 || newEvaluation.Note > 5)
                {
                    throw new ArgumentOutOfRangeException("LA nota se desbordo");
                }

                WriteLine("Ingreso correcto");
            }
            catch (ArgumentOutOfRangeException e)
            {
                WriteLine(e.Message);
            }
            catch (Exception)
            {
                throw new ArgumentException("Nota no es un numero valido");
            }
            finally
            {
                WriteLine("Finally");
            }
        }

        void Load(object? sender, EventArgs e)
        {
            
        }

        void Exit(object? sender, EventArgs e)
        {
            Printer.WriteTitle("Se ha cerrado la plataforma!");
        }

        #region Examples
        /*var school = new School("Inferno", 1995, SchoolTypes.Garden, InCity:"Medellin");
        WriteLine(school);
        WriteLine("---------------------");

        school.Courses = new Course[]{
            new Course() { Name = "101" },
            new Course() { Name = "201" },
            new Course() { Name = "301" }
        };

        school.CoursList = new List<Course>(){
            new Course() { Name = "101", WorkingDay = WorkingDayTypes.Morning },
            new Course() { Name = "201", WorkingDay = WorkingDayTypes.Morning },
            new Course() { Name = "301", WorkingDay = WorkingDayTypes.Morning }
        };
        school.CoursList.Add( new Course { Name = "102", WorkingDay = WorkingDayTypes.Afternoon} );
        school.CoursList.Add( new Course { Name = "202", WorkingDay = WorkingDayTypes.Afternoon} );

        var otherCollection = new List<Course>(){
            new Course() { Name = "103", WorkingDay = WorkingDayTypes.Evening },
            new Course() { Name = "203", WorkingDay = WorkingDayTypes.Evening },
            new Course() { Name = "303", WorkingDay = WorkingDayTypes.Evening }
        };
        school.CoursList.AddRange(otherCollection);
        school.CoursList.RemoveAll(Predicate);

        school.CoursList.RemoveAll(delegate (Course cour){
            return cour.Name == "303";
        });

        school.CoursList.RemoveAll((cour) => cour.Name == "201" && cour.WorkingDay == WorkingDayTypes.Morning);

        PrintSchoolCourses(school);

        static bool Predicate(Course obj)
        {
            return obj.Name == "301";
        }

        void PrintSchoolCourses(School school)
        {
            if (school != null)
            {
                Printer.WriteTitle("Cursos de la escuela");
                PrintCoursListForEach(school.CourseList);

                Printer.WriteTitle("Poliformismo");
                Printer.WriteTitle("Alumno");
                var studentTest = new Student { Name = "Alexis" };
                WriteLine(studentTest);

                BaseSchoolObj obj = studentTest;
                WriteLine(obj);

                //obj = new BaseSchoolObj{Name="Estefa"};
                WriteLine(obj);

                var evaluation = new Evaluation { Name = "Matematicas", Note = 3.2f };
                WriteLine(evaluation);

                obj = evaluation;
                if (obj is Student)
                {
                    Student RestoreStudent1 = (Student)obj;
                }
                Student RestoreStudent2 = obj as Student;


            }
        }

        void PrintCoursListForEach(List<Course> coursList)
        {
            foreach (var course in coursList)
            {
                WriteLine($"Nombre: {course.Name}, Id: {course.Id}");
            }
        }

        void PrintCoursesForEach(Course[] courses)
        {
            foreach (var course in courses)
            {
                WriteLine($"Nombre: {course.Name}, Id: {course.Id}");
            }
        }

        void PrintCoursesFor(Course[] courses)
        {
            for (int i = 0; i < courses.Length; i++)
            {
                WriteLine($"Nombre: {courses[i].Name}, Id: {courses[i].Id}");
            }
        }

        void PrintCoursesDoWhile(Course[] courses)
        {
            int counter = 0;
            do
            {
                WriteLine($"Nombre: {courses[counter].Name}, Id: {courses[counter].Id}");
                counter++;
            } while (counter < courses.Length);
        }

        void PrintCoursesWhile(Course[] courses)
        {
            int counter = 0;
            while (counter < courses.Length)
            {
                WriteLine($"Nombre: {courses[counter].Name}, Id: {courses[counter].Id}");
                counter++;
            }
        }*/
        #endregion
    }
}