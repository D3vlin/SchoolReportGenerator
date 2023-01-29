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
    }
}