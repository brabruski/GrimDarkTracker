using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class MissionModel
    {
        private IMissionType _mission;
        public IMissionType CurrentMission { get { return _mission; } }

        public bool IsTactical { get { return _mission.TacticalMission; } }

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

        public bool Discard { get { return _mission.Discard; } }
        public int Draws { get { return _mission.CalculateDraws(RoundNum, _player.Count); } }


        public MissionModel(MissionDetails m, int army)
        {
            _mission = MissionFactory.CreateMission(m);
            _player = new Player(army, _mission.TacticalMission);
        }

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
                if (!_mission.UpdateDiscard(_player.Round, _player.Count))
                    _player.AddRound();
                return _mission.UpdateDiscard(_player.Round, _player.Count);
            }
            else
            {
                _player.AddRound();
                return true;
            }
        }

        public void AddPoints(int p)
        {
            _player.AddPoints(p);
        }

        public void Deal()
        {
            if (IsTactical)
            {
                if (Draws > 0)
                    _player.Deal();
            }
            else
                _player.Deal();
        }

        //Default to null in case there are no Tactical Objectives
        public bool DiscardObj(Card card = null)
        {
            return _mission.DiscardObj(card);
        }
    }
}
