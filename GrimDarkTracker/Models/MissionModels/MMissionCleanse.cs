namespace GrimDarkTracker.Models.MissionModels
{
    class MMissionCleanse : MissionBase
    {
        public MMissionCleanse(MissionDetails m) : base(m)
        {
            _descrip = "Setup six Objective Markers on the battlefield. Objective Markers can be " +
                "placed anywhere on the battlefield, as long as each Objective Marker is not within 6\" " +
                "of the edge of the battlefield as well as not within 12\" of any other " +
                "Objective Marker.";
            _startingObj = 3;
            _tacticalMission = true;
        }

        public override int CalculateDraws(int round, int count)
        {
            int tempDraw = 3 - count;
            if (tempDraw < 0)
                tempDraw = 0;
            _draws = tempDraw;
            return _draws;
        }

        public override bool UpdateDiscard(int round, int count)
        {
            if (_discard)
                _discard = false;
            return _discard;

        }

        public override bool DiscardObj(Card card)
        {
            _discard = true;
            return _discard;
        }
    }
}
