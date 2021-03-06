﻿using System.Collections.ObjectModel;

namespace GrimDarkTracker.Models.MissionModels
{
    class EMissionScour : MissionBase
    {
        public EMissionScour(MissionDetails m) : base(m)
        {
            _objectives = new ObservableCollection<Objective> {
                new Objective(1, 1),
                new Objective(2, 2),
                new Objective(2, 3),
                new Objective(2, 4),
                new Objective(2, 5),
                new Objective(4, 6)
            };
            _descrip = "Setup six Objective Markers on the battlefield. " +
                "Objective Markers can be placed anywhere on the battlefield, as long as each " +
                "Objective Marker is not within 6\" of the edge of the battlefield as well as " +
                "not within 12\" of any other Objective Marker. Once both armies have been setup, " +
                "randomly select an Objective Marker to be the Superior Objective and then randomly " +
                "select an Objective Marker to be the Inferior Objective. At the end of the game, " +
                "players score Victory Points based on the Objective Markers they control. " +
                "The Superior Objective is worth 4 Victory Points and the Inferior Objective is " +
                "worth 1 Victory Point. All other Objective Markers are worth 2 Victory Points each.";
        }
    }
}
