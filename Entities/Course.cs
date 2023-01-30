namespace SchoolCore.Entities
{
    public class Course: BaseSchoolObj, IPlace
    {
        public WorkingDayTypes WorkingDay { get; set; }
        public List<Asignature> Asignatures { get; set; }
        public List<Student> Students { get; set; }
        public string address { get; set; }
        
        public Course()
        {
            WorkingDay = WorkingDayTypes.Unspecified;
            Asignatures = new List<Asignature>();
            Students = new List<Student>();
            address = "";
        }

        public void CleanAddress()
        {
            //
        }

        public override string ToString()
        {
            return $"┌Estado del curso {Name}\n│\n├Jornada: {WorkingDay}\n├Total Asignaturas: {Asignatures.Count()}\n├Total Alumnos: {Students.Count()}\n├Dirección: {address}";
        }
    }
}