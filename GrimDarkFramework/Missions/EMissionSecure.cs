using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class EMissionSecure : IMissionType
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

        public EMissionSecure(string type)
        {
            _objectives = new int[] { 3, 3 };
            _name = "Secure & Control";
            _descrip = "Players setup one Objective Marker each in their own Deployment Zone. " +
                "Objective Markers cannot be placed 6\" or less to the battlefield edge. " +
                "Each Objective Marker controlled by a unit at the end of the game is worth " +
                "3 Victory Points to the player whose unit is controlling it. " +
                "An Objective Marker is controlled by whichever player has more models within 3\" " +
                "of an Objective Marker.";
            _type = type;
            _startingObj = 0;
            _tacticalMission = false;
            _discard = false;
            _draws = 0;
        }

        public int CalculateDraws(int round, int count)
        {
            return 0;
        }

        public bool UpdateDiscard(int round, int count)
        {
            return _discard;
        }

        public bool DiscardObj(Card card)
        {
            return true;
        }
    }
}
