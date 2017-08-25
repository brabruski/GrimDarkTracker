namespace GrimDarkTracker.Models.MissionModels
{
    class MMissionEscalate : MissionBase
    {
        public MMissionEscalate(MissionDetails m) : base(m)
        {
            _descrip = "Setup six Objective Markers on the battlefield. Objective Markers can be placed anywhere on the battlefield, as long as each Objective" +
                " Marker is not within 6\" of the edge of the battlefield as well as not within 12\" of any " +
                "other Objective Marker.\n" +
                "\nTACTICAL PRIORITY - Before starting Turn 1, each player must choose a Tactical Type " +
                "(E.g.Take & Hold).You score an aditional 1 Victory Point for every Tactical Objective " +
                "of that type that you achieve however, you will lose 1 Victory Point for each Tactical Objective " +
                "of that type that you discard.\n" +
                "\nIf a Player has achieved more Tactical Objectives than their opponent of their selected type, " +
                "they score an additional Victory Point";
            _startingObj = 1;
            _tacticalMission = true;
        }

        public override int CalculateDraws(int round, int count)
        {
            int tempDraw = round - count;
            if (tempDraw < 0)
                tempDraw = 0;
            _draws = tempDraw;
            return _draws;
        }
    }
}
