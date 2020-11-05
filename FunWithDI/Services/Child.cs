namespace FunWithDI
{
    public class Child : IChild
    {
        private static int count;
        public int Id { get; set; }
        public Child()
        {
            Id = ++count;
        }
    }
}
