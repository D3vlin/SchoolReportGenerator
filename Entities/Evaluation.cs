using System;

namespace SchoolCore.Entities
{
    public class Evaluation: BaseSchoolObj
    {
        public Student Student { get; set; }
        public Asignature Asignature { get; set; }
        public float Note { get; set; }

        public Evaluation()
        {
            Student = new Student();
            Asignature = new Asignature();
            Note = 0f;
        }

        public override string ToString()
        {
            return $"Nombre: {Name}, Nota: {Note}, Id: {Id}, Type: {GetType()}";
        }
    }
}