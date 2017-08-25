using GrimDarkTracker.Models;

namespace GrimDarkTracker.Models.MissionModels
{
    //Allows all mission classes to inherit from a base mission class to avoid duplicate code
    class MissionBase : IMissionType
    {
        protected int[] _objectives;
        public int[] Objectives { get { return _objectives; } }

        protected string _name;
        public string MissionName { get { return _name; } }

        protected string _descrip;
        public string MissionDescription { get { return _descrip; } }

        protected string _type;
        public string MissionType { get { return _type; } }

        protected int _startingObj;
        public int StartingObjCards { get { return _startingObj; } }

        protected bool _tacticalMission;
        public bool TacticalMission { get { return _tacticalMission; } }

        protected bool _discard;
        public bool Discard { get { return _discard; } }
        protected int _draws;
        public int Draws { get { return _draws; } }

        public MissionBase(MissionDetails details)
        {
            _objectives = new int[] { 1, 1, 1, 1, 1, 1 };
            _name = details.MissionName;
            _type = details.MissionType;
            _startingObj = 0;
            _tacticalMission = false;
            _discard = false;
            _draws = 0;
        }

        public virtual int CalculateDraws(int round, int count)
        {
            return 0;
        }

        public virtual int CalculateDiscards(int round, int count)
        {
            return 0;
        }

        public virtual bool UpdateDiscard(int round, int count)
        {
            if (_discard)
                _discard = false;
            return _discard;
        }

        public virtual bool DiscardObj(Card card)
        {
            _discard = true;
            return _discard; ;
        }
    }
}

