using GrimDarkFramework.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Model
{
    public class Deck
    {
        public ObservableCollection<Card> TacticalDeck { get { return new ObservableCollection<Card>(_tacticalDeck); } }
        private List<Card> _tacticalDeck;
        private Random random = new Random();
        public int Count { get { return _tacticalDeck.Count(); } }

        //Constructor Depending on saved files or new decks
        public Deck()
        {
            _tacticalDeck = new List<Card>();
        }

        public Deck(int army=1)
        {
            var tempDeck = new XMLDatabase(army);
            _tacticalDeck = tempDeck.TactDeck as List<Card>;
            Shuffle();
        }

        public Deck(string FilePath)
        {
            var tempDeck = new XMLDatabase(FilePath);
            _tacticalDeck = tempDeck.TactDeck as List<Card>;
        }        

        //Allows you to see a card without dealing it
        public Card Peek(int cardId)
        {
            return TacticalDeck[cardId];
        }

        public void Add(Card cardToAdd)
        {
            _tacticalDeck.Add(cardToAdd);
        }


        //Overloaded, Deals a card from a deck, removes the card object from the deck and returns a reference to the card object
        public Card Deal()
        {
            return Deal(0);
        }

        public Card Deal(int index)
        {
            Card cardToDeal = _tacticalDeck[index];
            _tacticalDeck.RemoveAt(index);
            return cardToDeal;
        }

        public void Shuffle()
        {
            List<Card> shuffledList = new List<Card>();
            while (_tacticalDeck.Count > 0)
            {
                int cardIndexToMove = random.Next(_tacticalDeck.Count);
                shuffledList.Add(_tacticalDeck[cardIndexToMove]);
                _tacticalDeck.Remove(_tacticalDeck[cardIndexToMove]);
            }
            _tacticalDeck = shuffledList;
        }

    }
}
