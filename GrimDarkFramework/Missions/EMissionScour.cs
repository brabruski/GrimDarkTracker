using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class EMissionScour : IMission
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

        public EMissionScour(string type)
        {
            int[] _objectives = new int[] { 1, 2, 2, 2, 2, 4 };
            _name = "The Scouring";
            _descrip = "Setup six Objective Markers on the battlefield. " +
                "Objective Markers can be placed anywhere on the battlefield, as long as each " +
                "Objective Marker is not within 6\" of the edge of the battlefield as well as " +
                "not within 12\" of any other Objective Marker. Once both armies have been setup, " +
                "randomly select an Objective Marker to be the Superior Objective and then randomly " +
                "select an Objective Marker to be the Inferior Objective. At the end of the game, " +
                "players score Victory Points based on the Objective Markers they control. " +
                "The Superior Objective is worth 4 Victory Points and the Inferior Objective is " +
                "worth 1 Victory Point. All other Objective Markers are worth 2 Victory Points each.";
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
