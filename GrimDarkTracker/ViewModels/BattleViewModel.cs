using GrimDarkTracker.Models;
using GrimDarkTracker.Models.MissionModels;
using System;

namespace GrimDarkTracker.ViewModels
{
    public class BattleViewModel : BaseViewModel
    {
        private MissionDetails _details;
        private IMissionType _battle;
        private int _armyId;        

        public BattleViewModel(RelayMission m) : base(m)
        {
            _details = m.MDetails;
            _armyId = m.ArmyId;
            _battle = MissionFactory.CreateMission(_details);
        }

    }
}