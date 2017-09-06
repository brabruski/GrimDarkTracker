using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker.Models
{
    public class ObjectivePointsEventArgs : EventArgs
    {
        public int TotalAmount { get; private set; }        

        public ObjectivePointsEventArgs(int total)
        {
            TotalAmount = total;
        }
    }
}
