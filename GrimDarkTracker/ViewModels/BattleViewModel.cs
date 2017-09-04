using GrimDarkTracker.Models;
using GrimDarkTracker.Models.MissionModels;
using GrimDarkTracker.ViewModels.MissionViewModels;
using System;
using System.Collections.ObjectModel;

namespace GrimDarkTracker.ViewModels
{
    public class BattleViewModel : BaseViewModel
    {
        private MissionDetails _details;
        private IMissionType _battle;
        public IMissionViewModel CurrentMission { get; private set; }
        private int _armyId;
        public PlayerInfoViewModel PInfo { get; private set; }

        public bool KPAvailable { get; private set; }
        private bool _battleStarted;

        public RelayCommand AddRound { get; set; }
        public RelayCommand AddKPoint { get; set; }
        public RelayCommand DrawACard { get; set; }

        public bool IsTactical { get; private set; }
        public bool CanDrawACard { get; private set; }

        private Player _player;
        public Player Player { get { return _player; } }
        public int RoundNum { get { return _player.Round; } }
        public int VictoryPoints { get { return _player.VPoints; } }

        private bool _firstBlood;
        public bool FirstBlood
        {
            get { return _firstBlood; }
            set
            {
                if (_firstBlood != value)
                    _firstBlood = value;
                CalculateSpecialVictoryPoints();
                PInfo.UpdateInfo();
            }
        }
        private bool _slayWar;
        public bool SlayWar
        {
            get { return _slayWar; }
            set
            {
                if (_slayWar != value)
                    _slayWar = value;
                CalculateSpecialVictoryPoints();
                PInfo.UpdateInfo();
            }
        }
        private bool _lineBreak;
        public bool LineBreak
        {
            get { return _lineBreak; }
            set
            {
                if (_lineBreak != value)
                    _lineBreak = value;
                CalculateSpecialVictoryPoints();
                PInfo.UpdateInfo();
            }
        }

        public BattleViewModel(RelayMission m) : base(m)
        {
            _details = m.MDetails;
            _armyId = m.ArmyId;
            _battle = MissionFactory.CreateMission(_details);
            CurrentMission = MissionViewModelFactory.CreateViewModel(_details.Selector, _battle);
            _player = new Player(m.ArmyId, _battle);
            PInfo = new PlayerInfoViewModel(m.ViewModel, _player, _battle);
            _firstBlood = false;
            _lineBreak = false;
            _slayWar = false;
            CalculateSpecialVictoryPoints();
            _battleStarted = true;
            AddRound = new RelayCommand(CheckRound, BattleIsEnded);
            AddKPoint = new RelayCommand(AddPoint, KPAllowed);
            DrawACard = new RelayCommand(Draw, CanDraw);
            KPAvailable = KPAllowed();
            IsTactical = _battle.TacticalMission;
        }

        private void CalculateSpecialVictoryPoints()
        {
            int amount = 0;
            if (_slayWar)
                amount++;
            if (_firstBlood)
                amount++;
            if (_lineBreak)
                amount++;
            _player.SpecialVPoints = amount;
            _player.UpdateVictoryPoints();
        }

        private void CheckRound()
        {
            if (_player.Round <= 6)
            {
                if (IsTactical)
                {
                    if (!_battle.UpdateDiscard(_player.Round, _player.Count))
                        _player.AddRound();
                }
                else
                {
                    _player.AddRound();

                }
                PInfo.UpdateInfo();
            }
            BattleIsEnded();
        }

        private void AddPoint()
        {
            _player.AddPoints(1);
            PInfo.UpdateInfo();
        }

        private void AddPoints(int p)
        {
            _player.AddPoints(p);
        }

        private void Draw()
        {
            _player.Deal();
            PInfo.UpdateInfo();
        }

        public bool CanDraw()
        {
            _player.UpdateAll();
            if (IsTactical)
                _battle.CalculateDraws(PInfo.Round, _player.Count);
                        {
                if (_player.Draws > 0)
                return true;
            }
            return false;
            
        }

        public bool KPAllowed()
        {
            switch (_details.Selector)
            {
                case MissionEnum.EGuns:
                case MissionEnum.EMercy:
                    return true;

                case MissionEnum.ERelic:
                case MissionEnum.ERetrieve:
                case MissionEnum.EScour:
                case MissionEnum.ESecure:
                case MissionEnum.MCleanse:
                case MissionEnum.MCloak:
                case MissionEnum.MContact:
                case MissionEnum.MDeadlock:
                case MissionEnum.MEscalate:
                case MissionEnum.MSpoils:
                    return false;
                default:
                    return true;
            }
        }

        public bool BattleIsEnded()
        {
            if (_player.Round <= 6)
            {
                if (IsTactical)
                    return _battleStarted = !_battle.UpdateDiscard(_player.Round, _player.Count);
                if (!IsTactical)
                    return _battleStarted = true;
            }
            return _battleStarted = false;
        }

        //Default to null in case there are no Tactical Objectives
        public bool DiscardObj(Card card = null)
        {
            return _battle.DiscardObj(card);
        }

        #region View Bindings
        public string MissionName { get { return _battle.MissionType + ": " + _battle.MissionName; } }
        public string MissionDescrip { get { return _battle.MissionDescription; } }
        #endregion
    }
}