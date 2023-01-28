namespace SchoolCore.Entities
{
    public struct DictionaryKeys
    {
        public const string SCHOOL = "School";
        public const string COURSES = "Courses";
        public const string ASIGNATURES = "Asignatures";
        public const string STUDENTS = "Students";
        public const string EVALUATIONS = "Evaluatuations";
    }

    public enum DictionaryKey
    {
        School,
        Course,
        Asignature,
        Student,
        Evaluation
    }
}