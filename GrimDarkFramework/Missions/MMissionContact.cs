using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class MMissionContact : IMissionType
    {
        private int[] _objectives;
        public int[] Objectives { get { return _objectives; } }

        private string _name;
        public string MissionName { get { return _name; } }

        private string _descrip;
        public string MissionDescription { get { return _descrip; } }

        private string _type;
        public string MissionType { get { return _type; } }

        private int _startingObj;
        public int StartingObjCards { get { return _startingObj; } }

        private bool _tacticalMission;
        public bool TacticalMission { get { return _tacticalMission; } }

        private bool _discard;
        public bool Discard { get { return _discard; } }
        private int _draws;
        public int Draws { get { return _draws; } }

        public MMissionContact(MissionDetails m)
        {
            _objectives = new int[] { 1, 1, 1, 1, 1, 1 };
            _name = m.MissionName;
            _descrip = "Setup six Objective Markers on the battlefield. Objective Markers can be placed anywhere on " +
                "the battlefield, as long as each Objective Marker is not within 6\" of the edge of the battlefield " +
                "as well as not within 12\" of any other Objective Marker.\n" +
                "\nSTRATAGEM TEMPORARY COMMS UPLINK -A player may spend 3CP to generate a Tactical Objective " +
                "as long as they have fewer than 6 active objectives.";
            _type = m.MissionType;
            _startingObj = 6;
            _tacticalMission = true;
            _discard = false;
            _draws = 0;
        }

        public bool UpdateDiscard(int roundNum, int currentDeckCount)
        {
            if (_discard)
                _discard = false;
            return _discard;
        }

        public bool DiscardObj(Card card)
        {
            _discard = true;
            return _discard;
        }

        public int CalculateDraws(int round, int count)
        {
            int tempDraw = 6 - count;
            if (tempDraw < 0)
                tempDraw = 0;
            _draws = tempDraw;
            return _draws;
        }
    }
}
