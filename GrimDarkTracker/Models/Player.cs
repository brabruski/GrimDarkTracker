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

        public int SpecialVPoints { get; set; }
        private int _vpoints;
        public int VPoints { get; set; }
        private Deck _inPlayDeck;        
        public ObservableCollection<Card> InPlayDeck { get; set; }

        private Deck _tacticalDeck;
        public ObservableCollection<Card> TacticalDeck { get; set;}

        public int Count { get; set; }
        public string ArmyName { get; private set;}

        public Player(int armyId, bool isTactical)
        {
            SpecialVPoints = 0;
            _round = 1;
            _vpoints = 0;
            _inPlayDeck = new Deck();
            _tacticalDeck = new Deck(armyId);
            IsTactical = isTactical;
            InPlayDeck = _inPlayDeck.TacticalDeck();
            TacticalDeck = _tacticalDeck.TacticalDeck();            
            ArmyName = _tacticalDeck.Peek(0).ArmyName;
            Count = _inPlayDeck.CountCards();
        }

        public void UpdateSpecialPoints()
        {
            VPoints = _vpoints + SpecialVPoints;
        }

        public void UpdateAll()
        {
            _inPlayDeck.CountCards();
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
