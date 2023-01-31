namespace SchoolCore.Entities
{
    public sealed class Student: BaseSchoolObj
    {        
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

        private float GetEvaluationAverage()
        {
            if (Evaluations.Count() == 0)
                return 0f;
            
            float average = 0f;

            foreach (var evaluation in Evaluations)
            {
                average += evaluation.Note;
            }

            return MathF.Round(average / ((byte)Evaluations.Count()), 1);
        }

        public override string ToString()
        {
            return $"┌Estado del alumno {Name}\n│\n├ID: {Id}\n├Total Evaluaciones: {Evaluations.Count}\n├Promedio acumulado: {GetEvaluationAverage()}";
        }
    }
}