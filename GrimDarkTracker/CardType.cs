using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker
{
    class CardType
    {
        public CardType()
        {
            CardTypeId = 0;
            CardTypeName = "Testing Type";
        }

        public CardType(int cardTypeId, string cardTypeName)
        {
            this.CardTypeId = cardTypeId;
            this.CardTypeName = cardTypeName;
        }

        public int CardTypeId { get; set; }
        public string CardTypeName { get; set; }
        
    }
}
