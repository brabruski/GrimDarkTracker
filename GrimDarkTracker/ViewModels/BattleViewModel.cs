using GrimDarkTracker.Models;
using GrimDarkTracker.Models.MissionModels;
using System;
using System.Collections.ObjectModel;

namespace GrimDarkTracker.ViewModels
{
    public class BattleViewModel : BaseViewModel
    {
        private MissionDetails _details;
        private IMissionType _battle;
        public IMissionType CurrentMission { get { return _battle; } }
        private int _armyId;
        public PlayerInfoViewModel PInfo { get; private set; }

        public BattleViewModel(RelayMission m) : base(m)
        {
            _details = m.MDetails;
            _armyId = m.ArmyId;
            _battle = MissionFactory.CreateMission(_details);
            _player = new Player(m.ArmyId, _battle.TacticalMission);
            PInfo = new PlayerInfoViewModel(m.ViewModel, _player, _battle);            
        }

        public bool IsTactical { get { return _battle.TacticalMission; } }

        private Player _player;
        public Player Player { get { return _player; } }
        public int RoundNum { get { return _player.Round; } }
        public int VictoryPoints { get { return _player.VPoints; } }

        private bool _firstBlood = false;
        public bool FirstBlood { get { return _firstBlood; } }
        private bool _slayWar = false;
        public bool SlayWar { get { return _slayWar; } }
        private bool _lineBreak = false;
        public bool LineBreak { get { return _lineBreak; } }        

        public void GainSpecialMission(SpecialMissionEnum s)
        {
            switch (s)
            {
                case SpecialMissionEnum.FirstBlood:
                    ChangeCondition(_firstBlood);
                    return;
                case SpecialMissionEnum.LineBreaker:
                    ChangeCondition(_lineBreak);
                    return;
                case SpecialMissionEnum.SlayWarLord:
                    ChangeCondition(_slayWar);
                    return;
            }
        }

        private void ChangeCondition(bool condition)
        {
            if (condition)
                condition = false;
            else
                condition = true;
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
            _player.specialVPoints = amount;
        }

        public bool AddRound()
        {
            if (IsTactical)
            {
                if (!_battle.UpdateDiscard(_player.Round, _player.Count))
                    _player.AddRound();
                return _battle.UpdateDiscard(_player.Round, _player.Count);
            }
            else
            {
                _player.AddRound();
                return true;
            }
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