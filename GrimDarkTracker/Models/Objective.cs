using GrimDarkTracker.ViewModels;
using GrimDarkTracker.ViewModels.MissionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GrimDarkTracker.Models
{
    public class Objective
    {
        public static ObjectivePointsEventArgs TotalPoints
        {
            get
            {
                return _totalPoints;
            }
            set
            {
                if (_totalPoints != value)
                    _totalPoints = value;
            }
        }
        private static ObjectivePointsEventArgs _totalPoints;

        public int ObjectiveValue { get; private set; }

        //Use event to update player victory points when objectives are selected in view
        public event EventHandler<ObjectivePointsEventArgs> ObjectiveClaimed;

        protected void OnObjectiveClaimed(ObjectivePointsEventArgs e)
        {
            EventHandler<ObjectivePointsEventArgs> objectiveClaimed = ObjectiveClaimed;
            if (objectiveClaimed != null)
                objectiveClaimed(this, e);
        }

        public string ObjName { get; private set; }

        private bool _isUsed;
        public bool IsUsed
        {
            get { return _isUsed; }
            set {
                ClaimObjective();
                BattleViewModel.CalculateTotalObjectivePoints();
                OnObjectiveClaimed(TotalPoints);
                BattleViewModel.UpdateViews();
            }
        }

        public Objective(int objValue, int name) : this(objValue, "Objective #" + name)
        {
        }

        public Objective(int objValue, string name)
        {
            ObjectiveValue = objValue;
            ObjName = name;
            _isUsed = false;
        }

        public void ClaimObjective()
        {
            if (this._isUsed)
                this._isUsed = false;
            else
                this._isUsed = true;            
        }
    }
}
