namespace GrimDarkTracker.Models.MissionModels
{
    class EMissionGuns : MissionBase
    {
        public EMissionGuns(MissionDetails m) : base(m)
        {
            _objectives = new int[] { 3, 3, 3, 3 };
            _descrip = "Setup four Objective Markers on the battlefield. Objective Markers can be placed anywhere on the battlefield, " +
                "as long as each Objective Marker is not within 6\" of the edge of the battlefield as " +
                "well as not within 12\" of any other Objective Marker. " +
                "Each Objective Marker controlled by a unit at the end of the game is worth " +
                "3 Victory Points to the player whose unit is controlling it. " +
                "An Objective Marker is controlled by whichever player has more models within 3\" " +
                "of an Objective Marker. However, if an Objective Marker has a Heavy Support unit " +
                "within 3\", then that unit controls the Objective Marker regardless of the " +
                "amount of enemy models nearby.\n" +
                "\nBIG GUNS NEVER TIRE - Players score 1 Victory Point at the end of the game for " +
                "each enemy Heavy Support unit that was completely destroyed.";
        }        
    }
}
