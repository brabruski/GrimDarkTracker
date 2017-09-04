using GrimDarkTracker.Models;
using GrimDarkTracker.Models.MissionModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker.ViewModels
{
    public class PlayDeckViewModel : BaseViewModel
    {
        public ObservableCollection<Card> InPlayDeck { get; private set; }
        private List<Card> _tacticalDeck;
        private Player _player;
        private int _draws;
        private int _discard;
        private IMissionType _battle;


        public PlayDeckViewModel(MainViewModel m, Player p, IMissionType i) : base(m)
        {
            _player = p;
            _tacticalDeck = new List<Card>(p.TacticalDeck);
            InPlayDeck = p.InPlayDeck;
            _battle = i;
            _draws = _battle.CalculateDraws(p.Round, p.Count);
            _discard = p.Discards;
        }


        public int SelectedAmount
        {
            get
            {
                return this.SelectedAmount;
            }
            set
            {
                if (this.SelectedAmount != value)
                {
                    this.SelectedAmount = value;
                    RaisePropertyChanged("SelectedAmount");
                    Console.WriteLine(value);
                }
            }
        }

        public void AddPoints(int p)
        {
            _player.AddPoints(p);
        }

        public void Deal()
        {
            if (_draws > 0)
                _player.Deal();
            RaisePropertyChanged("InPlayDeck");
        }
}
}
