using GrimDarkTracker.Models;
using GrimDarkTracker.Models.MissionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker.ViewModels
{
    public class PlayerInfoViewModel : BaseViewModel
    {
        private int _drawsLeft;
        public int DrawsLeft
        {
            get { return _drawsLeft; }
            set
            {
                if (_drawsLeft != value)
                {
                    _drawsLeft = value;
                    RaisePropertyChanged("DrawsLeft");
                }
            }
        }

        private int _vPoints;
        public int VPoints
        {
            get { return _vPoints; }
            set
            {
                if (_vPoints != value)
                {
                    _vPoints = value;
                    RaisePropertyChanged("VPoints");
                }
            }
        }

        private int _discards;
        public int Discards
        {
            get { return _discards; }
            set
            {
                if (_discards != value)
                {
                    _discards = value;
                    RaisePropertyChanged("Discards");
                }
            }
        }

        private int _round;
        public int Round
        {
            get { return _round; }
            set
            {
                if (_round != value)
                {
                    _round = value;
                    RaisePropertyChanged("Round");
                }
            }
        }

        public string ArmyName { get; private set; }
        public bool TacticalFeatures { get; private set; }
        private Player _player;

        public PlayerInfoViewModel(MainViewModel v, Player p, IMissionType m) : base(v)
        {
            _player = p;
            VPoints = p.VPoints;
            ArmyName = p.ArmyName;
            Discards = m.CalculateDiscards(p.Round, p.Count);
            DrawsLeft = m.Draws;
            Round = p.Round;
            TacticalFeatures = p.IsTactical;
            UpdateInfo();
        }

        public void UpdateInfo()
        {
            _player.UpdateVictoryPoints();
            VPoints = _player.VPoints;
            Round = _player.Round;
            RaisePropertyChanged("DrawsLeft");
            RaisePropertyChanged("Discards");
            RaisePropertyChanged("VPoints");
            RaisePropertyChanged("Round");
            Console.WriteLine("PInfo Model After Updating Points: {0}", VPoints);
            Console.WriteLine("Player After Model: {0}", _player.VPoints);
        }
    }
}
