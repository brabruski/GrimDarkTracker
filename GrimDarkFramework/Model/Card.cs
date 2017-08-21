using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GrimDarkFramework.Model
{
    [XmlType("Card")]
    public class Card
    {
        [XmlAttribute("CardId")]
        public int CardId { get; set; }
        [XmlAttribute("CardName")]
        public string CardName { get; set; }
        [XmlAttribute("CardNum")]
        public int CardNum { get; set; }
        [XmlAttribute("CardDescrip")]
        public string CardDescrip { get; set; }

        [XmlAttribute("CardMinVP")]
        public int MinVP { get; set; }
        [XmlAttribute("CardMaxVP")]
        public int MaxVP { get; set; }

        [XmlAttribute("CardTypeName")]
        public string CardTypeName { get; set; }
        [XmlAttribute("CardTypeId")]
        public int CardTypeId { get; set; }

        [XmlAttribute("ArmyId")]
        public int ArmyId { get; set; }
        [XmlAttribute("ArmyName")]
        public string ArmyName { get; set; }
        [XmlAttribute("ArmyColour")]
        public string ArmyColour { get; set; }

        [XmlAttribute("Fort")]
        public bool Fort { get; set; }
        [XmlAttribute("Psyker")]
        public bool Psyker { get; set; }
        [XmlAttribute("Flyer")]
        public bool Flyer { get; set; }
        [XmlAttribute("HighWounds")]
        public bool HighWounds { get; set; }
        [XmlAttribute("BonusObj")]
        public bool BonusObj { get; set; }

        public ObservableCollection<PointRange> VictoryPointRange { get { return CreateList(MinVP, MaxVP); } }

        //Create list of victory points for combobox
        private ObservableCollection<PointRange> CreateList(int num1 = 1, int num2 = 1)
        {
            ObservableCollection<PointRange> tempList = new ObservableCollection<PointRange>();
            do 
            {
                tempList.Add(new PointRange(num1));
                num1++;
            } while (num1 <= num2);
            return tempList;
        }

        public override string ToString()
        {
            return CardName;
        }
    }
}
