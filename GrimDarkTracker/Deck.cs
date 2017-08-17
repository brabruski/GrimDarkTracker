using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker
{
    class Deck
    {
        private List<Card> TacticalDeck = new List<Card>();
        private Random random = new Random();

        public int Count { get { return TacticalDeck.Count; }}

        public Card Deal (int index)
        {
            Card CardToDeal = TacticalDeck[index];
            TacticalDeck.RemoveAt(index);
            return CardToDeal;
        }

        public void Add (Card cardToAdd)
        {
            TacticalDeck.Add(cardToAdd);
        }

        public void Shuffle()
        {
            List<Card> DeckShuffled = new List<Card>();
            while (TacticalDeck.Count > 0)
            {
                int CardToMove = random.Next(TacticalDeck.Count);
                DeckShuffled.Add(TacticalDeck[CardToMove]);
                TacticalDeck.RemoveAt(CardToMove);
            }
            TacticalDeck = DeckShuffled;
        }

    }
}
