using System;

namespace FunWithDI
{
    [Serializable]
    public class BottomLevel : IBottomLevel
    {
        private static int count;
        public int Id { get; set; }

        public IChild Child { get; set; }

        public BottomLevel(IChild child)
        {
            Id = ++count;
            Child = child;
        }
    }
}
