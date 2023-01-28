namespace SchoolCore.Entities
{
    public class Course: BaseSchoolObj, IPlace
    {
        public WorkingDayTypes WorkingDay { get; set; }
        public List<Asignature> Asignatures { get; set; }
        public List<Student> Students { get; set; }
        public string address { get; set; }

        public void CleanAddress()
        {
            //
        }
    }
}