using GrimDarkTracker.Models;

namespace GrimDarkTracker.Models.MissionModels
{
    class MissionFactory
    {
        public static IMissionType CreateMission(MissionDetails details)
        {
            
            switch (details.Selector)
            {
                case MissionEnum.ERetrieve:
                    return new EMissionRetrieval(details);
                case MissionEnum.EGuns:
                    return new EMissionGuns(details);
                case MissionEnum.EMercy:
                    return new EMissionMercy(details);
                case MissionEnum.ERelic:
                    return new EMissionRelic(details);                
                case MissionEnum.EScour:
                    return new EMissionScour(details);
                case MissionEnum.ESecure:
                    return new EMissionSecure(details);
                case MissionEnum.MCleanse:
                    return new MMissionCleanse(details);
                case MissionEnum.MCloak:
                    return new MMissionCloak(details);
                case MissionEnum.MContact:
                    return new MMissionContact(details);
                case MissionEnum.MDeadlock:
                    return new MMissionDeadlock(details);
                case MissionEnum.MEscalate:
                    return new MMissionEscalate(details);
                case MissionEnum.MSpoils:
                    return new MMissionSpoils(details);
                default:
                    return new EMissionMercy(details);
            }
        }
    }
}
