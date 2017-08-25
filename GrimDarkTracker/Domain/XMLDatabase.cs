﻿using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Xml.Linq;
using GrimDarkTracker.Models;


namespace GrimDarkTracker.Domain
{
    class XMLDatabase
    {
        private static string _xmlTypePath = "Db/CardTypes.xml";
        private static string _xmlArmyPath = "Db/Armies.xml";
        private static string _xmlCardPath = "Db/Cards.xml";
        public IEnumerable<Card> TactDeck;
        public List<Army> ArmyList {get { return RetrieveArmies(); } }

        public XMLDatabase()
        {
            TactDeck = LoadDeck();
        }

        public XMLDatabase(int choice)
        {
            TactDeck = LoadDeck(choice);
        }

        public XMLDatabase(string xmlPath)
        {
            _xmlCardPath = xmlPath;
            int savedArmyId = RetrieveSavedId(_xmlCardPath);
            TactDeck = LoadDeck(savedArmyId);
        }
        
        //Set card types in List<Card>
        private static IEnumerable<Card> LoadDeck(int armyChoice = 1)
        {
            List<Card> cardList = RetrieveCards(armyChoice);
            List<Army> armyList = RetrieveArmies();
            List<CardType> cardTypeList = RetrieveCardTypes();

            var deck = from card in cardList
                         join type in cardTypeList
                         on card.CardTypeId equals type.CardTypeId
                         join army in armyList
                         on card.ArmyId equals army.ArmyId
                         select new Card
                         {
                             CardId = card.CardId,
                             CardName = card.CardName,
                             CardNum = card.CardNum,
                             CardDescrip = card.CardDescrip,                             
                             MinVP = card.MinVP,
                             MaxVP = card.MaxVP,
                             CardTypeId = type.CardTypeId,
                             CardTypeName = type.CardTypeName,
                             ArmyId = army.ArmyId,
                             ArmyName = army.ArmyName,
                             ArmyColour = army.ArmyColour,
                             Flyer = card.Flyer,
                             Psyker = card.Psyker,
                             Fort = card.Fort,
                             HighWounds = card.HighWounds,
                             BonusObj = card.BonusObj,
                         };
            return (IEnumerable<Card>)deck;
        }

        //Methods to retrieve XML into lists
        //Load Cards from XML into List<Card>
        private static List<Card> RetrieveCards(int armyChoice)
        {
            XDocument cdoc = XDocument.Load(_xmlCardPath);

            var tempDeck = (from c in cdoc.Element("Cards").Elements("Card")
                            select new Card
                            {
                                CardId = int.Parse(c.Element("CardId").Value),
                                CardName = c.Element("CardName").Value,
                                CardDescrip = c.Element("CardDescrip").Value,
                                CardNum = int.Parse(c.Element("CardNum").Value),
                                MinVP = int.Parse(c.Element("CardMinVP").Value),
                                MaxVP = int.Parse(c.Element("CardMaxVP").Value),
                                CardTypeId = int.Parse(c.Element("CardTypeId").Value),
                                ArmyId = armyChoice,
                                Flyer = bool.Parse(c.Element("Flyer").Value),
                                Fort = bool.Parse(c.Element("Fort").Value),
                                Psyker = bool.Parse(c.Element("Psyker").Value),
                                HighWounds = bool.Parse(c.Element("HighWounds").Value),
                                BonusObj = bool.Parse(c.Element("BonusObj").Value),
                            }).ToList();
            return tempDeck;
        }        

        private static List<CardType> RetrieveCardTypes()
        {
            XDocument tdoc = XDocument.Load(_xmlTypePath);

            var tempDeck = (from t in tdoc.Element("CardTypes").Elements("CardType")
                            select new CardType
                            {
                                CardTypeId = int.Parse(t.Element("CardTypeId").Value),
                                CardTypeName = t.Element("CardTypeName").Value,
                            }).ToList();
            return tempDeck;
        }

        private static List<Army> RetrieveArmies()
        {
            XDocument adoc = XDocument.Load(_xmlArmyPath);

            var tempDeck = (from a in adoc.Element("Armies").Elements("Army")
                            select new Army
                            {
                                ArmyId = int.Parse(a.Element("ArmyId").Value),
                                ArmyName = a.Element("ArmyName").Value,
                                ArmyColour = a.Element("ArmyColour").Value,
                            }).ToList();
            return tempDeck;
        }

        //Retrieve Army ID from Existing Deck
        private int RetrieveSavedId(string xmlCardPath)
        {
            XDocument cdoc = XDocument.Load(xmlCardPath);
            int id;

            var tempId = (from c in cdoc.Element("Cards").Elements("Card")
                          select new
                          {
                              id = int.Parse(c.Element("ArmyId").Value),
                          });
            id = tempId.FirstOrDefault().id;
            return id;
        }
    }
}