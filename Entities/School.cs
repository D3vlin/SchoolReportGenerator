namespace SchoolCore.Entities
{
    public class School: BaseSchoolObj, IPlace
    {
        public int FoundationYear { get; set; }        
        public string country { get; set; }
        public string city { get; set; }        
        public SchoolTypes schoolType { get; set; }

        public Course[] Courses { get; set; }

        public List<Course> CourseList { get; set; }
        public string address { get; set; }

        public School(string InName, int InFoundationYear, SchoolTypes InSchoolType, string InCountry = "", string InCity = "")
        {
            this.Name = InName;
            this.FoundationYear = InFoundationYear;
            this.country = InCountry;
            this.city = InCity;
            this.Courses = new Course[0];
            this.CourseList = new List<Course>();
            this.address = "";
        }

        public override string ToString()
        {
            return $"Escuela\nNombre: {Name}, Tipo: {schoolType},\nPais: {country}, Ciudad: {city}";
        }

        public void CleanAddress()
        {
            foreach (var course in CourseList)
            {
                course.CleanAddress();
            }
        }
    }
}