using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class MMissionCloak : MissionBase
    {
        public MMissionCloak(MissionDetails m) : base(m)
        {
            _descrip = "Setup six Objective Markers on the battlefield. " +
                "Objective Markers can be placed anywhere on the battlefield, as long as each Objective Marker " +
                "is not within 6\" of the edge of the battlefield as well as not within 12\" of any other " +
                "Objective Marker.\n" +
                "\nSTRATAGEM FLARES - Players may spend 1CP to select an enemy's unit. " +
                "For the duration of your turn, your units can shoot at that unit without penalty from " +
                "Cover of Darkness.\n" +
                "\nSECRET ORDERS - Players must keep their Tactical Objectives secret from each other. " +
                "Only reveal Tactical Objectives when they are achieved.\n" +
                "\nCOVER OF DARKNESS - When rolling to hit in the Shooting Phase, subtract 1 from the roll " +
                "if the target is more than 18\" away.";
            _startingObj = 3;
            _tacticalMission = true;
        }

        public override int CalculateDraws(int round, int count)
        {
            int tempCount = count - 3;
            if (tempCount < 0)
                tempCount = 0;
            _draws = tempCount;
            return _draws;
        }

        public override bool UpdateDiscard(int round, int count)
        {
            if (_discard)
                _discard = false;
            return _discard;

        }
    }
}
