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
    public class PlayDeckViewModel : ObservableViewModel
    {
        private Deck _inPlayDeck;
        public ObservableCollection<Card> InPlayDeck { get; set; }
        private Deck _tacticalDeck;
        private Player _player;
        private IMissionType _mission;
        
        public PlayDeckViewModel(IMissionType m, Player p)
        {
            _player = p;
            _mission = m;
            _inPlayDeck = p.InPlayDeck;
            _tacticalDeck = p.TacticalDeck;
        }        
    }
}
