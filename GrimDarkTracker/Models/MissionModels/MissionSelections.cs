namespace GrimDarkTracker.Models.MissionModels
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
