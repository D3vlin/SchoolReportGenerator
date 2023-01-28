namespace SchoolCore.Entities
{
    public sealed class Student: BaseSchoolObj
    {        
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}