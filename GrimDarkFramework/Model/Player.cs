using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkFramework.Model
{
    class Player
    {
        private int _round;
        public int Round { get { return _round; } }

        public int specialVPoints = 0;
        private int _vpoints;
        public int VPoints { get { return _vpoints + specialVPoints; } }
        private Deck _inPlayDeck;        
        public Deck InPlayDeck { get { return _inPlayDeck; } }
        private Deck _tacticalDeck;
        public Deck TacticalDeck { get { return _tacticalDeck; } }
        public int Count { get { return _inPlayDeck.Count; } }

        public Player(int army)
        {
            _round = 1;
            _vpoints = 0;
            _inPlayDeck = new Deck();
            _tacticalDeck = new Deck(army);
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
    }
}
