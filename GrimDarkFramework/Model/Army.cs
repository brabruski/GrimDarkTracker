using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Model
{
    [Serializable]
    public class Army
    {
        public int ArmyId { get; set; }
        public string ArmyName { get; set; }
        public string ArmyColour { get; set; }  
    }
}
