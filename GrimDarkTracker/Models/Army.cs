using System;

namespace GrimDarkTracker.Models
{
    [Serializable]
    public class Army
    {
        public int ArmyId { get; set; }
        public string ArmyName { get; set; }
        public string ArmyColour { get; set; }
        public bool Available { get; set; }

        public override string ToString()
        {
            return ArmyName;
        }
    }
}
