using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class EMissionRelic : IMissionType
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

        public EMissionRelic(string type)
        {
            _objectives = new int[] { 1 };
            _name = "The Relic";
            _descrip = "Place a single Objective Marker at the centre of the battlefield to represent " +
                "the Relic. If a player's unit is carrying the Relic at the end of the game, " +
                "then they win a Major Victory. If no player is carrying the Relic, then the player " +
                "with a model closest to the relic wins a Minor Victory. If no player has a unit " +
                "carrying the Relic or player units are equally distanced to the Relic, then the game " +
                "is a Draw.\n" +
                "\nRELIC - Any INFANTRY model can move onto the Relic and will then automatically pick it up. " +
                "The Relic then remains with that model until it is dropped (the model must be slain or flee for the " +
                "Relic to be dropped).A model carrying the Relic cannot embark in any TRANSPORT, move more than 9\" " +
                "in any single phase or leave the battlefield.";
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
