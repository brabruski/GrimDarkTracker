using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class EMissionMercy : IMissionType
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

        public EMissionMercy(string type)
        {
            _objectives = new int[0];
            _name = "No Mercy";
            _descrip = "Each player scores 1 Victory Point for each enemy unit that is destroyed.";
            _type = type;
            _startingObj = 0;
            _tacticalMission = false;
            _discard = false;
            _draws = 0;
        }

        public int CalculateDiscards(int round, int count)
        {
            return 0;
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
