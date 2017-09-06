using System.Collections.ObjectModel;

namespace GrimDarkTracker.Models.MissionModels
{
    class EMissionMercy : MissionBase
    {
        public EMissionMercy(MissionDetails m) : base(m)
        {
            _objectives = new ObservableCollection<Objective> {};
            _descrip = "Each player scores 1 Victory Point for each enemy unit that is destroyed.";
        }
    }
}
