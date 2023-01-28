namespace SchoolCore.Entities
{
    public interface IPlace
    {
        string address { get; set; }

        void CleanAddress();
    }
}