using GrimDarkTracker.Models;
using GrimDarkTracker.Models.MissionModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker.ViewModels.MissionViewModels
{
    class MaelstromViewModel : IMissionViewModel
    {
        public ObservableCollection<Objective> Objectives { get; private set; }
        private static IMissionType _mission;
        public PlayDeckViewModel PlayDeck;

        public MaelstromViewModel(IMissionType m, Player p)
        {
            _mission = m;
            Objectives = m.Objectives;
            PlayDeck = new PlayDeckViewModel(m, p);
        }
    }
}
