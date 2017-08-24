using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class EMissionMercy : MissionBase
    {
        public EMissionMercy(MissionDetails m) : base(m)
        {
            _objectives = new int[0];
            _descrip = "Each player scores 1 Victory Point for each enemy unit that is destroyed.";
        }
    }
}
