namespace SchoolCore.Entities
{
    public abstract class BaseSchoolObj
    {
        public string Id { get; private set; }
        public string Name { get; set; }

        public BaseSchoolObj()
        {
            Id = Guid.NewGuid().ToString();
            Name = "";
        }

        public override string ToString()
        {
            return $"Nombre: {Name}, Id: {Id}, Type: {GetType()}";
        }
    }
}