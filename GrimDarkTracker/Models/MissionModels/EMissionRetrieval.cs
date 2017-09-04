using System.Collections.ObjectModel;

namespace GrimDarkTracker.Models.MissionModels
{
    class EMissionRetrieval : MissionBase
    {        
        public EMissionRetrieval(MissionDetails m) : base(m)
        {
            _objectives = new ObservableCollection<Objective> {
                new Objective(3, 1),
                new Objective(3, 2),
                new Objective(3, 3),
                new Objective(3, 4)
            };
            _descrip = "Setup four Objective Markers on the battlefield. Objective Markers can be placed anywhere on the battlefield, as long as each Objective Marker is not within 6\" of the edge of the battlefield as well as not within 12\" of any other Objective Marker. Each Objective Marker controlled by a unit at the end of the game is worth 3 Victory Points to the player whose unit is controlling it. An Objective Marker is controlled by whichever player has more models within 3\" of an Objective Marker.";           
        }
    }
}
