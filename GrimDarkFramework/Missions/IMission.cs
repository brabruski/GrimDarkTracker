using GrimDarkFramework.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Model
{
    interface IMission
    {
        int[] Objectives { get; }
        string MissionName { get; }
        string MissionDescription { get; }
        string MissionType { get; }

        int StartingObjCards { get; }
        bool TacticalMission { get; }
        bool Discard { get; }
        int Draws { get; }

        bool UpdateDiscard(int roundNum, int currentDeckCount);
        bool DiscardObj(Card card);
        int CalculateDraws(int round, int count);
    }
}
