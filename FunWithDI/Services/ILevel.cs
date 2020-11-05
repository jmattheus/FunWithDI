namespace FunWithDI
{
    public interface ILevel
    {
        int Id { get; set; }
        IChild Child { get; set; }
    }
}
