using GrimDarkFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class MissionFactory
    {
        public static IMission CreateMission(MissionEnum m)
        {
            switch (m)
            {
                case MissionEnum.ERetrieve:
                    return new EMissionRetrieval();
                //case MissionEnum.EGuns:
                //    return new MissionGuns();
                //case MissionEnum.EMercy:
                //    return new MissionMercy();
                //case MissionEnum.ERelic:
                //    return new MissionRelic();                
                //case MissionEnum.EScour:
                //    return new MissionScour();
                //case MissionEnum.ESecure:
                //    return new MissionSecure();
                //case MissionEnum.MCleanse:
                //    return new MissionCleanse();
                //case MissionEnum.MCloak:
                //    return new MissionCloak();
                //case MissionEnum.MContact:
                //    return new MissionContact();
                //case MissionEnum.MDeadlock:
                //    return new MissionDeadlock();
                //case MissionEnum.MEscalate:
                //    return new MissionEscalate();
                //case MissionEnum.MSpoils:
                //    return new MissionSpoils();
                default:
                    return new EMissionRetrieval();
            }            
        }
    }
}
