using SchoolCore.Entities;

namespace SchoolCore.App
{
    public class Reporter
    {
        Dictionary<DictionaryKey, IEnumerable<BaseSchoolObj>> _dictionary;

        public Reporter(Dictionary<DictionaryKey, IEnumerable<BaseSchoolObj>> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            _dictionary = dictionary;
        }
        
        public IEnumerable<Evaluation> GetEvaluationList()
        {
            //var list = _dictionary.GetValueOrDefault(DictionaryKey.School);
            IEnumerable<Evaluation> response = null;
            if (_dictionary.TryGetValue(DictionaryKey.Evaluation, out IEnumerable<BaseSchoolObj> list))
                return list.Cast<Evaluation>();
            else
                return  new List<Evaluation>();
        }
        
        public IEnumerable<string> GetAsignatureList(out IEnumerable<Evaluation> evaluationList)
        {
            evaluationList = GetEvaluationList();
            
            return (from evaluation in evaluationList
                    select evaluation.Asignature.Name).Distinct();
        }
        
        public IEnumerable<string> GetAsignatureList()
        {
            return GetAsignatureList(out var dummy);
        }
        
        public Dictionary<string, IEnumerable<Evaluation>> GetDictionaryEvaluationXAsignature()
        {
            var response = new Dictionary<string, IEnumerable<Evaluation>>();
            var asignatureList = GetAsignatureList(out var evaluationList);

            foreach (var asignature in asignatureList)
            {
                var evaluationAsignature = from evaluation in evaluationList
                                            where evaluation.Asignature.Name == asignature
                                            select evaluation;

                response.Add(asignature, evaluationAsignature);
            }
            
            return response;
        }

        public Dictionary<string, IEnumerable<object>> GetPromStudentXAsignature()
        {
            var response = new Dictionary<string, IEnumerable<object>>();
            var dicEvaluationXAsignature = GetDictionaryEvaluationXAsignature();

            foreach (var asignature in dicEvaluationXAsignature)
            {
                var studentAverage = from evaluation in asignature.Value
                            group evaluation by new {
                                evaluation.Student.Id,
                                evaluation.Student.Name
                            }
                            into evaluationXStudent
                            select new StudentAverage{
                                Id = evaluationXStudent.Key.Id,
                                Name = evaluationXStudent.Key.Name,
                                Average = evaluationXStudent.Average(eval => eval.Note)
                            };
                
                response.Add(asignature.Key, studentAverage);
            }

            return response;
        }
    }
}