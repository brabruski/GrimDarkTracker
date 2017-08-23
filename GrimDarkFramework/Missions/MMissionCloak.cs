using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class MMissionCloak : IMissionType
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

        public MMissionCloak(MissionDetails m)
        {
            _objectives = new int[] { 1, 1, 1, 1, 1, 1 };
            _name = m.MissionName;
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
            _type = m.MissionType;
            _startingObj = 3;
            _tacticalMission = true;
            _discard = false;
            _draws = 0;
        }

        public int CalculateDraws(int round, int count)
        {
            int tempCount = count - 3;
            if (tempCount < 0)
                tempCount = 0;
            _draws = tempCount;
            return _draws;
        }

        public bool UpdateDiscard(int round, int count)
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
    }
}
