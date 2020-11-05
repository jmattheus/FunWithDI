using FunWithDI.Controllers;
using System;

namespace FunWithDI
{
    public class MidLevel : IMidLevel
    {
        private static int count;
        public int Id { get; set; }
        public int GlobalId { get; set; }

        public IBottomLevel BottomLevel { get; set; }
        public IChild Child { get; set; }
        public MidLevel(IBottomLevel bottomLevel, IChild child)
        {
            Id = ++count;
            BottomLevel = bottomLevel;
            Child = child;
        }
    }
}
