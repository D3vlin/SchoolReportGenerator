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

        public School(string InName)
        {
            this.Name = InName;
            this.FoundationYear = 1995;
            this.country = "Colombia";
            this.city = "Medellin";
        }

        public School(string InName, int InFoundationYear) => (Name, FoundationYear) = (InName, InFoundationYear);

        public School(string InName, int InFoundationYear, SchoolTypes InSchoolType, string InCountry = "", string InCity = "") => (Name, FoundationYear, country, city) = (InName, InFoundationYear, InCountry, InCity);

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