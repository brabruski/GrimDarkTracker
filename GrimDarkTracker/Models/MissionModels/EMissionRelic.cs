using System.Collections.ObjectModel;

namespace GrimDarkTracker.Models.MissionModels
{
    class EMissionRelic : MissionBase
    {
        public EMissionRelic(MissionDetails m) : base(m)
        {
            _objectives = new ObservableCollection<Objective> {
                new Objective(1, "Relic")
            };
            _descrip = "Place a single Objective Marker at the centre of the battlefield to represent " +
                "the Relic. If a player's unit is carrying the Relic at the end of the game, " +
                "then they win a Major Victory. If no player is carrying the Relic, then the player " +
                "with a model closest to the relic wins a Minor Victory. If no player has a unit " +
                "carrying the Relic or player units are equally distanced to the Relic, then the game " +
                "is a Draw.\n" +
                "\nRELIC - Any INFANTRY model can move onto the Relic and will then automatically pick it up. " +
                "The Relic then remains with that model until it is dropped (the model must be slain or flee for the " +
                "Relic to be dropped).A model carrying the Relic cannot embark in any TRANSPORT, move more than 9\" " +
                "in any single phase or leave the battlefield.";            
        }
    }
}
