namespace GrimDarkTracker.Models.MissionModels
{
    class EMissionSecure : MissionBase
    {
        public EMissionSecure(MissionDetails m) : base(m)
        {
            _objectives = new int[] { 3, 3 };
            _descrip = "Players setup one Objective Marker each in their own Deployment Zone. " +
                "Objective Markers cannot be placed 6\" or less to the battlefield edge. " +
                "Each Objective Marker controlled by a unit at the end of the game is worth " +
                "3 Victory Points to the player whose unit is controlling it. " +
                "An Objective Marker is controlled by whichever player has more models within 3\" " +
                "of an Objective Marker.";
        }
    }
}
