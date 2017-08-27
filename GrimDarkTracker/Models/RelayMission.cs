using GrimDarkTracker.Models.MissionModels;
using GrimDarkTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker.Models
{
    public class RelayMission
    {
        public MissionDetails MDetails {get; set;}
        public int ArmyId { get; set; }
        public MainViewModel ViewModel { get; set; }

        public RelayMission(MainViewModel v, MissionDetails m, int a)
        {
            MDetails = m;
            ArmyId = a;
            ViewModel = v;
        }
    }
}
