using GrimDarkFramework.Domain;
using GrimDarkFramework.Missions;
using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.ViewModel
{
    class MissionSelectViewModel : INotifyPropertyChanged
    {
        private XMLDatabase _db;
        private static List<Army> _armies;
        public List<Army> Armies { get { return _armies; } }
        public ObservableCollection<MissionDetails> MissionList;
        
        public MissionSelectViewModel()
        {
            _db = new XMLDatabase();
            _armies = _db.ArmyList;
            DataContext = this;
        }

        int _SelectedMission;
        public int SelectedMission
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
                }
            }
        }

        private void SwitchList(int type)
        {
            if (type == 1)
                MissionList = new ObservableCollection<MissionDetails>(_maelstrom);
            else
                MissionList = new ObservableCollection<MissionDetails>(_eternal);
        }

        #region Mission Lists
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

        public Dictionary<int, string> MissionTypes = new Dictionary<int, string>()
        {
            { 1, "Eternal War" },
            { 2, "Maelstrom of War" }
        };
        #endregion Mission Lists

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
    }
}
