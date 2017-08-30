using GrimDarkTracker.Domain;
using GrimDarkTracker.Models;
using GrimDarkTracker.Models.MissionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GrimDarkTracker.ViewModels
{
    class BattleSelectViewModel : BaseViewModel
    {
        private static List<Army> _armies;
        public List<Army> Armies { get { return _armies; } }
        public List<MissionDetails> MissionList { get { return _missionList; } }
        public List<MissionSelections> MissionTypes { get { return _missionTypes; } }
        private MissionDetails _missionDetails;
        private RelayMission _relayParam;
        public RelayMission RelayParam { get { return _relayParam; } }

        //Relay command to call 'ToBattleSelect' function
        public RelayCommand<RelayMission> SwitchToBattle { get; private set; }

        public BattleSelectViewModel(MainViewModel main) : base(main)
        {
            _armies = XMLDatabase.ArmyList;
            _missionList = new List<MissionDetails>();
            _missionDetails = new MissionDetails();
            _relayParam = new RelayMission(main, _missionDetails, 1);
            _selectedArmy = 1;
            SwitchToBattle = new RelayCommand<RelayMission>(ToBattle, ValidSelections);
        }

        #region Player's Selected Properties
        MissionEnum _selectedMission;
        public MissionEnum SelectedMission
        {
            get
            {
                return _selectedMission;
            }
            set
            {
                if (_selectedMission != value)
                {
                    _selectedMission = value;
                    _missionDetails.Selector = value;
                    _missionDetails.MissionName = ReturnMissionName(value);
                    RaisePropertyChanged("SelectedMission");
                    RaisePropertyChanged("MissionList");
                }
            }
        }

        private string ReturnMissionName(MissionEnum m)
        {
            foreach (MissionDetails t in _missionList)
            {
                if (m == t.Selector)
                    return t.MissionName;
            }
            return Constants.PlaceHolderMissionName;
        }

        int _selectedArmy;
        public int SelectedArmy
        {
            get
            {
                return _selectedArmy;
            }
            set
            {
                if (_selectedArmy != value)
                {
                    _selectedArmy = value;
                    RelayParam.ArmyId = _selectedArmy;
                    RaisePropertyChanged("SelectedArmy");
                }
            }
        }

        int _selectedMissionType;
        public int SelectedMissionType
        {
            get
            {
                return _selectedMissionType;
            }
            set
            {
                if (_selectedMissionType != value)
                {
                    _selectedMissionType = value;                    
                    SwitchList(_selectedMissionType);
                    _missionDetails.TypeSelect(_selectedMission);
                    _selectedMission = 0;
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
            RaisePropertyChanged("SelectedMission");
        }

        #region Mission Lists
        private List<MissionDetails> _missionList;
        private List<MissionDetails> _eternal = new List<MissionDetails>()
        {
            new MissionDetails(MissionEnum.ESecure, Constants.MSecure),
            new MissionDetails(MissionEnum.EScour, Constants.MScour),
            new MissionDetails(MissionEnum.ERetrieve, Constants.MRetrieve),
            new MissionDetails(MissionEnum.ERelic, Constants.MRelic),
            new MissionDetails(MissionEnum.EMercy, Constants.MMercy),
            new MissionDetails(MissionEnum.EGuns, Constants.MGuns),
        };

        private List<MissionDetails> _maelstrom = new List<MissionDetails>()
        {
            new MissionDetails(MissionEnum.MSpoils, Constants.MSpoil),
            new MissionDetails(MissionEnum.MEscalate, Constants.MEscalate),
            new MissionDetails(MissionEnum.MDeadlock, Constants.MDead),
            new MissionDetails(MissionEnum.MContact, Constants.MContact),
            new MissionDetails(MissionEnum.MCloak, Constants.MCloak),
            new MissionDetails(MissionEnum.MCleanse, Constants.MClean),
        };

        private List<MissionSelections> _missionTypes = new List<MissionSelections>()
        {
            new MissionSelections(Constants.Eternal, 1),
            new MissionSelections(Constants.Maelstrom, 2),
        };
        #endregion

        //Calling ViewModel function. Passed ViewModel Type
        public void ToBattle(RelayMission param)
        {
            Navigate<BattleViewModel>(param);
        }

        public bool ValidSelections(RelayMission param)
        {
            if (param != null)
            {
                string tempMission = param.MDetails.MissionName;
                MissionEnum tempEnum = param.MDetails.Selector;
                if (tempEnum == 0 || tempMission == Constants.PlaceHolderMissionName)
                    return false;
            }
            if (param == null || _selectedMission == 0)
                return false;
            return true;
        }

    }
}
