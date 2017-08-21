using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GrimDarkUI.Models
{

    public class Card
    {
        private string _cardName;
        public string CardName { get { return _cardName; } set { _cardName = value; } }

        private int _cardNum;
        public int CardNum { get { return _cardNum; } set { _cardNum = value; } }

        private int _maxVP;
        public int MaxVP { get { return _maxVP; } set { _maxVP = value; } }

        public Card(string name, int num, int max)
        {
            _cardName = name;
            _cardNum = num;
            _maxVP = max;
        }
        
        public ObservableCollection<PointRange> VictoryPointRange { get { return CreateList(MaxVP); } }

        //Create list of victory points for combobox
        private ObservableCollection<PointRange> CreateList(int num1)
        {
            int num2 = 1;
            ObservableCollection<PointRange> tempList = new ObservableCollection<PointRange>();
            do 
            {
                tempList.Add(new PointRange(num2));
                num2++;
            } while (num2 <= num1);
            return tempList;
        }

        public override string ToString()
        {
            return CardName;
        }

        
    }
}
