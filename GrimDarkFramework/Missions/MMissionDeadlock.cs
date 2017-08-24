using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class MMissionDeadlock : MissionBase
    {
        public MMissionDeadlock(MissionDetails m) : base(m)
        {
            _descrip = "Setup six Objective Markers on the battlefield. " +
                "Objective Markers can be placed anywhere on the battlefield, as long as each " +
                "Objective Marker is not within 6\" of the edge of the battlefield as well as not " +
                "within 12\" of any other Objective Marker. \n" +
                " \nSTRATEGIC DEADLOCK - From the start of the Third Round of battle, Strategems " +
                "used by players cost double Command Points.";
            _startingObj = 6;
            _tacticalMission = true;
        }

        public override int CalculateDraws(int round, int count)
        {
            int tempDraw = 7 - round - count;
            if (tempDraw < 0)
                tempDraw = 0;
            _draws = tempDraw;
            return _draws;
        }

        public override bool UpdateDiscard(int round, int count)
        {
            if (_discard && (CalculateDiscards(round, count) >= 0))
                _discard = false;

            return _discard;
        }

        public override int CalculateDiscards(int round, int count)
        {
            int tempDiscards = 7 - round - count;            
            return tempDiscards;
        }
    }
}
