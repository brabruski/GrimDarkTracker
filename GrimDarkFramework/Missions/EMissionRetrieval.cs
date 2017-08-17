using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class EMissionRetrieval : IMission
    {
        public int[] Objectives => throw new NotImplementedException();

        public string MissionName => throw new NotImplementedException();

        public string MissionDescription => throw new NotImplementedException();

        public string MissionType => throw new NotImplementedException();

        public int StartingObjCards => throw new NotImplementedException();

        public bool TacticalMission => throw new NotImplementedException();

        public int Discards => throw new NotImplementedException();

        public int Draws => throw new NotImplementedException();

        public int CalculateDiscards(int round, int count)
        {
            throw new NotImplementedException();
        }

        public int CalculateDraws(int round, int count)
        {
            throw new NotImplementedException();
        }
    }
}
