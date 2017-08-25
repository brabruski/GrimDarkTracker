namespace GrimDarkTracker.Models.MissionModels
{
    class MMissionSpoils : MissionBase
    {
        public MMissionSpoils(MissionDetails m) : base(m)
        {
            _descrip = "Setup six Objective Markers on the battlefield. Objective Markers can be placed anywhere on the " +
                "battlefield, as long as each Objective Marker is not within 6\" of the edge of the battlefield as well as " +
                "not within 12\" of any other Objective Marker.\n" +
                "\nPRECIOUS CARGO - any Tactical Objective titled \"Secure Objective X\" where X is the number of the " +
                "Objective Marker, can be scored by either player no matter which player generated it. In addition, " +
                "these Tactical Objectives can only be discarded when achieved.";
            _startingObj = 3;
            _tacticalMission = true;
        }

        public override bool DiscardObj(Card card)
        {
            if (card.CardNum <= 26)
                return false;
            else
                return _discard = true;            
        }

        public override int CalculateDraws(int round, int count)
        {
            int tempDraw = 3 - count;
            if (tempDraw < 0)
                tempDraw = 0;
            _draws = tempDraw;
            return _draws;
        }
    }
}
