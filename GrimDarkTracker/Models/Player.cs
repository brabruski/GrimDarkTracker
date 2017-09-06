using GrimDarkTracker.Models.MissionModels;
using System;
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
        public int ObjectiveVPoints { get; set; }
        private int _vpoints;
        public int VPoints { get; set; }
        private Deck _inPlayDeck;        
        public Deck InPlayDeck { get { return _inPlayDeck; } }

        private Deck _tacticalDeck;
        public Deck TacticalDeck { get { return _tacticalDeck; } }

        public int Count { get; set; }
        public string ArmyName { get; private set;}

        public Player(int armyId, IMissionType mission)
        {
            SpecialVPoints = 0;
            ObjectiveVPoints = 0;
            _round = 1;
            _vpoints = 0;
            _inPlayDeck = new Deck();
            _tacticalDeck = new Deck(armyId);
            IsTactical = mission.TacticalMission;            
            ArmyName = _tacticalDeck.Peek(0).ArmyName;
            Count = _inPlayDeck.CountCards();
            AddEvents(mission.Objectives);
        }

        public void UpdateVictoryPoints()
        {
            VPoints = _vpoints + ObjectiveVPoints + SpecialVPoints;
        }

        public void UpdateAll()
        {
            _inPlayDeck.CountCards();
            UpdateVictoryPoints();
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

        //Subscribe to Objective Event
        private void AddEvents(ObservableCollection<Objective> objective)
        {
            foreach (Objective o in objective)
            {
                o.ObjectiveClaimed += objective_ObjectiveClaimed;
            }
        }

        private void objective_ObjectiveClaimed(object sender, EventArgs e)
        {
            if (e is ObjectivePointsEventArgs)
            {
                ObjectivePointsEventArgs objectivePointsEventArgs = e as ObjectivePointsEventArgs;
                ObjectiveVPoints = objectivePointsEventArgs.TotalAmount;
                UpdateVictoryPoints();                
            }
        }
    }
}
