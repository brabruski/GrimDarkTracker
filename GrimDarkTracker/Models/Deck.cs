using GrimDarkTracker.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace GrimDarkTracker.Models
{
    public class Deck
    {
        private ObservableCollection<Card> _tacticalDeck;
        
        private Random random = new Random();       

        //Constructor Depending on saved files or new decks
        public Deck()
        {
            _tacticalDeck = new ObservableCollection<Card>();            
        }

        public Deck(int army=1)
        {
            var tempDeck = new XMLDatabase(army);
            _tacticalDeck = new ObservableCollection<Card>(tempDeck.TactDeck);            
            _tacticalDeck = Shuffle(_tacticalDeck);
        }

        public ObservableCollection<Card> TacticalDeck()
        {
            return _tacticalDeck;
        }

        public int CountCards()
        {

            if (_tacticalDeck == null)
                return 0;
            return _tacticalDeck.Count();
        }

        //Allows you to see a card without dealing it
        public Card Peek(int cardId)
        {
            return _tacticalDeck[cardId];
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

        public ObservableCollection<Card> Shuffle(ObservableCollection<Card> deck)
        {
            if (deck != null)
            {
                ObservableCollection<Card> shuffledList = new ObservableCollection<Card>();
                while (deck.Count > 0)
                {
                    int cardIndexToMove = random.Next(deck.Count);
                    shuffledList.Add(deck[cardIndexToMove]);
                    deck.Remove(deck[cardIndexToMove]);
                }
                return shuffledList;
            }
            return deck;
        }
    }
}
