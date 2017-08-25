namespace GrimDarkTracker.Models.MissionModels
{
    class MMissionContact : MissionBase
    {
        public MMissionContact(MissionDetails m) : base(m)
        {
            _descrip = "Setup six Objective Markers on the battlefield. Objective Markers can be placed anywhere on " +
                "the battlefield, as long as each Objective Marker is not within 6\" of the edge of the battlefield " +
                "as well as not within 12\" of any other Objective Marker.\n" +
                "\nSTRATAGEM TEMPORARY COMMS UPLINK -A player may spend 3CP to generate a Tactical Objective " +
                "as long as they have fewer than 6 active objectives.";
            _startingObj = 6;
            _tacticalMission = true;
        }

        public override int CalculateDraws(int round, int count)
        {
            int tempDraw = 6 - count;
            if (tempDraw < 0)
                tempDraw = 0;
            _draws = tempDraw;
            return _draws;
        }
    }
}
