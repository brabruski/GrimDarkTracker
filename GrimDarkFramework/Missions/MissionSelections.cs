using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Missions
{
    class MissionSelections
    {
        private string _typeName;
        public string TypeName { get { return _typeName; } }
        private int _typeId;
        public int TypeId { get { return _typeId; } }

        public MissionSelections(string name, int id)
        {
            _typeName = name;
            _typeId = id;
        }
    }
}
