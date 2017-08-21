using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Model
{
    [Serializable]
    public class CardType
    {
        public string CardTypeName { get; set; }
        public int CardTypeId { get; set; }

        public override string ToString()
        {
            return CardTypeName;
        }
    }
}
