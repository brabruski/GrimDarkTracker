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
        public int TotalObjectivePoints { get; set; }
        private static IMissionType _mission;

        public EternalViewModel(IMissionType m)
        {
            _mission = m;
            Objectives = m.Objectives;
            TotalObjectivePoints = 0;
        }

        public static void CalculateTotalObjectivePoints(IMissionType m)
        {
            int t = m.CalculateObjectives();
            Objective.TotalPoints = new ObjectivePointsEventArgs(t);            
        }

        public static void CalculateTotalObjectivePoints()
        {
            CalculateTotalObjectivePoints(_mission);
        }

    }
}
