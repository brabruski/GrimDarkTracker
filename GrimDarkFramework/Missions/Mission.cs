using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class Mission
    {
        private IMission _mission;
        public IMission CurrentMission { get { return _mission; } }

        public bool IsTactical { get { return _mission.TacticalMission; } }

        public Player Player { get { return _player; } }
        private Player _player;
        public int RoundNum { get { return _player.Round; } }
        public int VictoryPoints { get { return _player.VPoints; } }

        private bool _firstBlood;
        public bool FirstBlood { get { return _firstBlood; } }
        private bool _slayWar;
        public bool SlayWar { get { return _slayWar; } }
        private bool _lineBreak;
        public bool LineBreak { get { return _lineBreak; } }
        
        public int Discards { get { return _mission.CalculateDiscards(RoundNum, _player.Count); } }
        public int Draws { get { return _mission.CalculateDraws(RoundNum, _player.Count); } }


        public Mission(MissionEnum m, int army)
        {
            _mission = MissionFactory.CreateMission(m);
            _player = new Player(army);
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

        public void AddRound()
        {
            _player.AddRound();
        }

        public void AddPoints(int p)
        {
            _player.AddPoints(p);
        }

        public void Deal()
        {
            _player.Deal();
        }
    }
}
