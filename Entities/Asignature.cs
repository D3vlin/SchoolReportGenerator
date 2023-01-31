using System;

namespace SchoolCore.Entities
{
    public class Asignature: BaseSchoolObj
    {
        public override string ToString()
        {
            return $"┌Estado de la asignature {Name}\n│\n├ID: {Id}";
        }
    }
}