using static System.Console;
using SchoolCore.Entities;
using SchoolCore.Util;

namespace SchoolCore.App
{
    public sealed class SchoolEngine
    {
        public School school { get; set; }

        public SchoolEngine() => school = new School("", 0, SchoolTypes.Unspecified);

        public void Initialize()
        {
            school = new School("BlackClowm", 1995, SchoolTypes.Secundary, "Colombia", "Medellin");

            LoadCourses();
            LoadAsignatures();
            LoadEvaluations();
        }

        private void LoadEvaluations()
        {
            var random = new Random();
            foreach (var course in school.CourseList)
            {
                foreach (var asignature in course.Asignatures)
                {
                    foreach (var student in course.Students)
                    {

                        for (int i = 0; i < 5; i++)
                        {
                            var evaluation = new Evaluation
                            {
                                Asignature = asignature,
                                Name = $"{asignature.Name} Nota:{i + 1}",
                                Note = MathF.Round(5 * (float) random.NextDouble(), 2),
                                Student = student
                            };
                            student.Evaluations.Add(evaluation);
                        }
                    }
                }
            }
        }

        private void LoadAsignatures()
        {
            foreach (var course in school.CourseList)
            {
                var asignatureList = new List<Asignature>(){
                            new Asignature{Name="Matemáticas"} ,
                            new Asignature{Name="Educación Física"},
                            new Asignature{Name="Castellano"},
                            new Asignature{Name="Ciencias Naturales"}
                };
                course.Asignatures = asignatureList;
            }
        }

        private List<Student> RandomStudentGenerator(int amount)
        {
            string[] names1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] names2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
            string[] lastNames1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

            var StudentList = from n1 in names1
                              from n2 in names2
                              from l1 in lastNames1
                              select new Student { Name = $"{n1} {n2} {l1}" };

            return StudentList.OrderBy((student) => student.Id).Take(amount).ToList();
        }

        private void LoadCourses()
        {
            school.CourseList = new List<Course>(){
                new Course() { Name = "101", WorkingDay = WorkingDayTypes.Morning },
                new Course() { Name = "201", WorkingDay = WorkingDayTypes.Morning },
                new Course() { Name = "301", WorkingDay = WorkingDayTypes.Afternoon },
                new Course() { Name = "401", WorkingDay = WorkingDayTypes.Afternoon },
                new Course() { Name = "501", WorkingDay = WorkingDayTypes.Evening }
            };
            Random random = new Random();
            foreach (var course in school.CourseList)
            {
                int RandomAmount = random.Next(5, 20);
                course.Students = RandomStudentGenerator(RandomAmount);
            }
        }

        public IReadOnlyList<BaseSchoolObj> GetSchoolObjects(
            bool getEvaluations = true,
            bool getStudents = true,
            bool getAsignatures = true,
            bool getCourses = true
        )
        {
            return GetSchoolObjects(out int dummy, out dummy, out dummy, out dummy);
        }
        
        public IReadOnlyList<BaseSchoolObj> GetSchoolObjects(
            out int evaluationsCounter,
            bool getEvaluations = true,
            bool getStudents = true,
            bool getAsignatures = true,
            bool getCourses = true
        )
        {
            return GetSchoolObjects(out evaluationsCounter, out int dummy, out dummy, out dummy);
        }
        
        public IReadOnlyList<BaseSchoolObj> GetSchoolObjects(
            out int evaluationsCounter,
            out int studentsCounter,
            bool getEvaluations = true,
            bool getStudents = true,
            bool getAsignatures = true,
            bool getCourses = true
        )
        {
            return GetSchoolObjects(out evaluationsCounter, out studentsCounter, out int dummy, out dummy);
        }
        
        public IReadOnlyList<BaseSchoolObj> GetSchoolObjects(
            out int evaluationsCounter,
            out int studentsCounter,
            out int asignaturesCounter,
            bool getEvaluations = true,
            bool getStudents = true,
            bool getAsignatures = true,
            bool getCourses = true
        )
        {
            return GetSchoolObjects(out evaluationsCounter, out studentsCounter, out asignaturesCounter, out int dummy);
        }

        public IReadOnlyList<BaseSchoolObj> GetSchoolObjects(
            out int evaluationsCounter,
            out int studentsCounter,
            out int asignaturesCounter,
            out int coursesCounter,
            bool getEvaluations = true,
            bool getStudents = true,
            bool getAsignatures = true,
            bool getCourses = true
        )
        {
            evaluationsCounter = studentsCounter = asignaturesCounter = coursesCounter = 0;

            var objList = new List<BaseSchoolObj>();
            objList.Add(school);
            
            if(getCourses)
                objList.AddRange(school.CourseList);

            coursesCounter += school.CourseList.Count;
            foreach (var course in school.CourseList)
            {
                asignaturesCounter += course.Asignatures.Count;
                studentsCounter += course.Students.Count;

                if(getAsignatures)
                    objList.AddRange(course.Asignatures);

                if(getStudents)
                    objList.AddRange(course.Students);

                if (getEvaluations)
                {
                    foreach (var student in course.Students)
                    {
                        objList.AddRange(student.Evaluations);
                        evaluationsCounter += student.Evaluations.Count;
                    }
                }
            }

            return objList.AsReadOnly();
        }

        public Dictionary<DictionaryKey, IEnumerable<BaseSchoolObj>> GetObjectDictionary()
        {
            var dictionary = new Dictionary<DictionaryKey, IEnumerable<BaseSchoolObj>>();
            dictionary.Add(DictionaryKey.School, new[] {school});
            dictionary.Add(DictionaryKey.Course, school.CourseList.Cast<BaseSchoolObj>());

            var asignatureList = new List<Asignature>();
            var studentList = new List<Student>();
            var evaluationList = new List<Evaluation>();
            foreach(var course in school.CourseList)
            {
                asignatureList.AddRange(course.Asignatures);
                studentList.AddRange(course.Students);
                
                foreach (var student in course.Students)
                {
                    evaluationList.AddRange(student.Evaluations);
                }
            }
            dictionary.Add(DictionaryKey.Asignature, asignatureList.Cast<BaseSchoolObj>());                
            dictionary.Add(DictionaryKey.Student, studentList.Cast<BaseSchoolObj>());
            dictionary.Add(DictionaryKey.Evaluation, evaluationList.Cast<BaseSchoolObj>());

            return dictionary;
        }

        public void PrintSchoolStatus(Dictionary<DictionaryKey, IEnumerable<BaseSchoolObj>> dictionary)
        {
            IEnumerable<BaseSchoolObj> schoolList = dictionary.GetValueOrDefault(DictionaryKey.School) ?? new List<School>();
            if (schoolList.Count() > 0)
            {
                foreach (var school in schoolList)
                    Printer.WriteResult(school.ToString());
            }
            
            Printer.PressAnyKey();
        }

        public void PrintDictionary(
            Dictionary<DictionaryKey, IEnumerable<BaseSchoolObj>> dictionary,
            bool printEvaluation = false
        )
        {
            foreach (var obj in dictionary)
            {
                Printer.WriteTitle($"{obj.Key}");
                
                foreach (var value in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case DictionaryKey.School:
                            Console.WriteLine($"Escuela: {value}");
                        break;

                        case DictionaryKey.Course:
                            var tmpCourse = value as Course;
                            if (tmpCourse != null)
                            {
                                int counter = ((Course)value).Students.Count;
                                Console.WriteLine($"Curso: {value.Name}, Cantidad Alumnos {counter}");
                            }
                        break;

                        case DictionaryKey.Student:
                            Console.WriteLine($"Alumno: {value.Name}");
                        break;

                        case DictionaryKey.Evaluation:
                            if (printEvaluation)
                                Console.WriteLine(value);
                        break;

                        default:
                            Console.WriteLine(value);
                        break;
                    }
                }
            }
        }
    }
}