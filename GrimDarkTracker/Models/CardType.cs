using System;


namespace GrimDarkTracker.Models
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
