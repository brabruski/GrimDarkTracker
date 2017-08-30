using System.Collections.ObjectModel;
using System.Linq;

namespace GrimDarkTracker.Models
{
    public class Player
    {
        private int _round;
        public int Round { get { return _round; } }

        public bool IsTactical { get; private set; }
        public int Discards { get; set; }
        public int Draws { get; set; }

        public int specialVPoints = 0;
        private int _vpoints;
        public int VPoints { get { return _vpoints + specialVPoints; } }
        private Deck _inPlayDeck;        
        public ObservableCollection<Card> InPlayDeck { get; private set;}
        private Deck _tacticalDeck;
        public ObservableCollection<Card> TacticalDeck { get; private set; }
        public int Count { get { return _inPlayDeck.Count; } }
        public string ArmyName { get; private set;}

        public Player(int armyId, bool isTactical)
        {
            _round = 1;
            _vpoints = 0;
            _inPlayDeck = new Deck();
            _tacticalDeck = new Deck(armyId);
            IsTactical = isTactical;
            InPlayDeck = _inPlayDeck.TacticalDeck();
            TacticalDeck = _tacticalDeck.TacticalDeck();            
            ArmyName = _tacticalDeck.Peek(0).ArmyName;
        }

        public void AddPoints(int p)
        {
            _vpoints += p;
        }

        public void AddRound()
        {
            _round++;
        }

        public void Deal()
        {
            _inPlayDeck.Add(_tacticalDeck.Deal());            
        }        

        public string GetArmyName()
        {
            Card tempCard;
            tempCard = _tacticalDeck.Peek(0);
            return tempCard.ArmyName;
        }
    }
}
