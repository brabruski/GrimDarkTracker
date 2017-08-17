using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Model
{
    public class PointRange
    {
        private int _amount;
        public int Amount { get { return _amount; } }

        public PointRange(int num)
        {
            _amount = num;
        }

    } 
}
