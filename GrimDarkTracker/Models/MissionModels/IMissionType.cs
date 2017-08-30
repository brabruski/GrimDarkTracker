namespace GrimDarkTracker.Models.MissionModels
{
    public interface IMissionType
    {
        int[] Objectives { get; }
        string MissionName { get; }
        string MissionDescription { get; }
        string MissionType { get; }

        int StartingObjCards { get; }
        bool TacticalMission { get; }
        bool Discard { get; }
        int Draws { get; }

        bool UpdateDiscard(int roundNum, int currentDeckCount);
        bool DiscardObj(Card card);
        int CalculateDraws(int round, int count);
        int CalculateDiscards(int round, int count);
    }
}
