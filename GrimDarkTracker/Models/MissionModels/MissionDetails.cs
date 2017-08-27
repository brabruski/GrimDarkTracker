namespace GrimDarkTracker.Models.MissionModels
{
    public class MissionDetails
    {
        private MissionEnum _selector;
        public MissionEnum Selector {
            get {
                return _selector;
            }
            set
            {
                if (_selector != value)
                    _selector = value;
            }
        }
        private string _missionName;
        public string MissionName { get
            {
                return _missionName; }
            set
            {
                if (_missionName != value)
                    _missionName = value;
            }
        }
        private string _missionType;
        public string MissionType {
            get
            {
                return _missionType;
            }
            set
            {
                if (_missionType != value)
                    TypeSelect(_selector);
            }
        }

        private string _eternal = "Eternal War";
        private string _maelstrom = "Maelstrom of War";

        public MissionDetails()
        {
            _missionName = "No Mission Selected";
            _selector = MissionEnum.EMercy;
            TypeSelect(_selector);
        }

        public MissionDetails(MissionEnum m, string name)
        {
            _selector = m;
            _missionName = name;
            TypeSelect(m);
        }

        public void TypeSelect(MissionEnum m)
        {
            if ((int)m > 6)
                _missionType = _maelstrom;
            else
                _missionType = _eternal;
        }
    }
}
