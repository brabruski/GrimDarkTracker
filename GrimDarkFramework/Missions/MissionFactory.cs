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
            string eternal = "Eternal War";
            string maelstrom = "Maelstrom of War";

            switch (m)
            {
                case MissionEnum.ERetrieve:
                    return new EMissionRetrieval(eternal);
                case MissionEnum.EGuns:
                    return new EMissionGuns(eternal);
                case MissionEnum.EMercy:
                    return new EMissionMercy(eternal);
                case MissionEnum.ERelic:
                    return new EMissionRelic(eternal);                
                case MissionEnum.EScour:
                    return new EMissionScour(eternal);
                case MissionEnum.ESecure:
                    return new EMissionSecure(eternal);
                case MissionEnum.MCleanse:
                    return new MMissionCleanse(maelstrom);
                case MissionEnum.MCloak:
                    return new MMissionCloak(maelstrom);
                //case MissionEnum.MContact:
                //    return new MissionContact(maelstrom);
                case MissionEnum.MDeadlock:
                    return new MMissionDeadlock(maelstrom);
                //case MissionEnum.MEscalate:
                //    return new MissionEscalate(maelstrom);
                //case MissionEnum.MSpoils:
                //    return new MissionSpoils(maelstrom);
                default:
                    return new EMissionMercy(eternal);
            }
        }
    }
}
