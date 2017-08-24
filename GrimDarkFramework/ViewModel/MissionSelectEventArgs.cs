using GrimDarkFramework.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.ViewModel
{
    class MissionSelectEventArgs : EventArgs

    {
        public MissionDetails Mission { get; private set; }
        public int Army { get; private set; }

        public MissionSelectEventArgs(MissionDetails m, int army)
        {
            this.Mission = m;
            this.Army = army;
        }
    }
}
