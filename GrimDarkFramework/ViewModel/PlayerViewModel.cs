using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GrimDarkFramework.ViewModel
{
    class PlayerViewModel : ViewModelBase
    {

        private string _armyName;
        public string ArmyName { get { return _armyName; } }
        private int _round;
        public int RoundNum { get { return _round; } }
        private int _discards;
        public int Discards { get { return _discards; } }
        private int _draws;
        public int Draws { get { return _draws; } }
        private int _vp;
        public int VPoints { get { return _vp; } }
        public bool IsTactical { get; private set; }

        public PlayerViewModel(Player player)
        {
            IsTactical = player.IsTactical;
            _armyName = player.GetArmyName();
            _round = player.Round;
            _vp = player.VPoints;
            _discards = player.Discards;
            _draws = player.Draws;
        }

        public void UpdatePlayerView(string name)
        {
            RaisePropertyChanged(name);
        }        
    }
}

