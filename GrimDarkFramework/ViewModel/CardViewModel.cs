using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrimDarkFramework.Missions;
using GrimDarkFramework.Model;

namespace GrimDarkFramework.ViewModel
{
    class CardViewModel : ViewModelBase
    {
        MissionDetails details;
        MissionFactory fact;
        
        public CardViewModel()
        {
            fact = new MissionFactory();
            details = new MissionDetails(MissionEnum.ESecure, "Secure & Slave");
            IMissionType Emission = MissionFactory.CreateMission(details);
        }
    }
}
