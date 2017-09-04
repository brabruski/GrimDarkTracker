﻿using GrimDarkTracker.Models.MissionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker.ViewModels.MissionViewModels
{
    class MissionViewModelFactory
    {
        public static IMissionViewModel CreateViewModel(MissionEnum m, IMissionType battle)
        {
            switch (m)
            {
                case MissionEnum.ERetrieve:                    
                case MissionEnum.EGuns:                    
                case MissionEnum.EMercy:                    
                case MissionEnum.ERelic:                    
                case MissionEnum.EScour:                    
                case MissionEnum.ESecure:
                    return new EternalViewModel(battle);
                case MissionEnum.MCleanse:                    
                case MissionEnum.MCloak:                    
                case MissionEnum.MContact:
                case MissionEnum.MDeadlock:
                case MissionEnum.MEscalate:
                case MissionEnum.MSpoils:
                    return new MaelstromViewModel(battle);
                default:
                    return new EternalViewModel(battle);
            }
        }
    }
}
