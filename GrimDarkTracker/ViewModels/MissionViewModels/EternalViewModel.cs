using GrimDarkTracker.Models;
using GrimDarkTracker.Models.MissionModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrimDarkTracker.ViewModels.MissionViewModels
{
    class EternalViewModel : ObservableViewModel, IMissionViewModel
    {
        public ObservableCollection<Objective> Objectives { get; private set; }
        private static IMissionType _mission;

        public EternalViewModel(IMissionType m, Player p)
        {
            _mission = m;
            Objectives = m.Objectives;
        }

    }
}
