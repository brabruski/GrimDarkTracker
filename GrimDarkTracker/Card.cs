using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker
{
    class Card
    {
        public Card ()
        {
            CardId = 0;
            CardName = "Test";
            CardNum = 1;
            CardType = new CardType ();
            CardDescrip = "A placeholder card for testing.";
            CardMinVP = 1;
            CardMaxVP = 1;
            Flyer = false;
            Psyker = false;
            Fort = false;
            HighWound = false;
            BonusObj = false;
        }

        public Card(int cardId, string cardName, int cardNum, CardType cardType, string cardDescrip,
            int cardMin, int cardMax, bool fly, bool psyk, bool fort, bool high, bool bonus)
        {
            this.CardId = cardId;
            this.CardName = cardName;
            this.CardNum = cardNum;
            this.CardType = cardType;
            this.CardDescrip = cardDescrip;
            this.CardMinVP = cardMin;
            this.CardMaxVP = cardMax;
            this.Flyer = fly;
            this.Psyker = psyk;
            this.Fort = fort;
            this.HighWound = high;
            this.BonusObj = bonus;
        }

        public int CardId { get; private set; }
        public string CardName { get; private set; }
        public int CardNum { get; private set; }
        public CardType CardType { get; private set; }
        public string CardDescrip { get; private set; }
        public int CardMinVP { get; private set; }
        public int CardMaxVP { get; private set; }
        public bool Flyer { get; private set; }
        public bool Psyker { get; private set; }
        public bool Fort { get; private set; }
        public bool HighWound { get; private set; }
        public bool BonusObj { get; private set; }

        
        public void BonusObjective()
        {
            if (BonusObj)
            {
                BonusObj = false;
            }
            else
            {
                BonusObj = true;
            }
        }
    }
}
