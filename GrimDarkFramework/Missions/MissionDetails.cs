using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class MissionDetails
    {
        private MissionEnum _selector;
        public MissionEnum Selector { get { return _selector; } }
        private string _missionName;
        public string MissionName { get { return _missionName; } }
        private string _missionType;
        public string MissionType { get { return _missionType; } }

        private string _eternal = "Eternal War";
        private string _maelstrom = "Maelstrom of War";

        public MissionDetails(MissionEnum m, string name)
        {
            _selector = m;
            _missionName = name;
            TypeSelect(m);
        }

        private void TypeSelect(MissionEnum m)
        {
            if ((int)m <= 6)
                _missionType = _eternal;
            else
                _missionType = _maelstrom;
        }
    }
}
