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
            return $"┌Resultado de evaluación de {Name}\n│\n├ID: {Id}\n├Alumno: {Student.Name}\n├Nota: {Note}";
        }
    }
}