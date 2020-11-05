using System;

namespace FunWithDI
{
    public class TopLevel : ITopLevel
    {
        private static int count;
        public int Id { get; set; }
        public IMidLevel MidLevel { get; set; }
        public IChild Child { get; set; }
        public TopLevel(IMidLevel midLevel, IChild child)
        {
            Id = ++count;
            MidLevel = midLevel;
            Child = child;
        }
    }
}
