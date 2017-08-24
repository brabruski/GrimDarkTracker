using GrimDarkFramework.Domain;
using GrimDarkFramework.Missions;
using GrimDarkFramework.Model;
using System.Collections.Generic;
using System.ComponentModel;


namespace GrimDarkFramework.ViewModel
{
    class MissionSelectViewModel : ViewModelBase
    {
        private XMLDatabase _db;
        private static List<Army> _armies;
        public List<Army> Armies { get { return _armies; } }
        public List<MissionDetails> MissionList { get { return _missionList; } }
        public List<MissionSelections> MissionTypes { get { return _missionTypes; } }

        public MissionSelectViewModel()
        {
            _db = new XMLDatabase();
            _armies = _db.ArmyList;
            _missionList = new List<MissionDetails>();
        }

        #region Selected Properties
        MissionEnum _SelectedMission;
        public MissionEnum SelectedMission
        {
            get
            {
                return _SelectedMission;
            }
            set
            {
                if (_SelectedMission != value)
                {
                    _SelectedMission = value;
                    RaisePropertyChanged("SelectedMission");
                }
            }
        }

        int _SelectedArmy;
        public int SelectedArmy
        {
            get
            {
                return _SelectedArmy;
            }
            set
            {
                if (_SelectedArmy != value)
                {
                    _SelectedArmy = value;
                    RaisePropertyChanged("SelectedArmy");
                }
            }
        }


        int _SelectedMissionType;
        public int SelectedMissionType
        {
            get
            {
                return _SelectedMissionType;
            }
            set
            {
                if (_SelectedMissionType != value)
                {
                    _SelectedMissionType = value;
                    SwitchList(_SelectedMissionType);
                    RaisePropertyChanged("SelectedMissionType");
                    RaisePropertyChanged("SelectedMission");
                    
                }
            }
        }
#endregion 

        //Change MissionList in View Based on Mission Type Selected
        private void SwitchList(int id)
        {
            if (id == 1)
                _missionList = _eternal;
            else
                _missionList = _maelstrom;
            RaisePropertyChanged("MissionList");
        }

        #region Mission Lists
        private List<MissionDetails> _missionList;
        private List<MissionDetails> _eternal = new List<MissionDetails>()
        {
            new MissionDetails(MissionEnum.ESecure, "Secure & Control"),
            new MissionDetails(MissionEnum.EScour, "The Scouring"),
            new MissionDetails(MissionEnum.ERetrieve, "Retrieval Mission"),
            new MissionDetails(MissionEnum.ERelic, "The Relic"),
            new MissionDetails(MissionEnum.EMercy, "No Mercy"),
            new MissionDetails(MissionEnum.EGuns, "Big Guns Never Tire"),
        };

        private List<MissionDetails> _maelstrom = new List<MissionDetails>()
        {
            new MissionDetails(MissionEnum.MSpoils, "Spoils of War"),
            new MissionDetails(MissionEnum.MEscalate, "Tactical Escalation"),
            new MissionDetails(MissionEnum.MDeadlock, "Deadlock"),
            new MissionDetails(MissionEnum.MContact, "Contact Lost"),
            new MissionDetails(MissionEnum.MCloak, "Cloak & Shadows"),
            new MissionDetails(MissionEnum.MCleanse, "Cleanse & Capture"),
        };

        private List<MissionSelections> _missionTypes = new List<MissionSelections>()
        {
            new MissionSelections("Eternal War", 1),
            new MissionSelections("Maelstrom of War", 2),
        };
        #endregion


    }
}
