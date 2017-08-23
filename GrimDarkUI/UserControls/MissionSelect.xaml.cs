using GrimDarkUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrimDarkUI.UserControls
{
    /// <summary>
    /// Interaction logic for MissionSelect.xaml
    /// </summary>
    public partial class MissionSelect : UserControl, INotifyPropertyChanged
    {
        public ObservableCollection<Card> MissionName { get { return _missionName; } set { _missionName = value; } }
        private ObservableCollection<Card> _missionName;

        public MissionSelect()
        {
            InitializeComponent();
            LoadList();
            DataContext = this;
        }

        public void LoadList()
        {
            _missionName = new ObservableCollection<Card>()
            {
                new Card("Hoot", 1, 1),
                new Card("Wibble", 2, 1),
                new Card("Poppy", 3, 6),
                new Card("Boolock", 4, 3),
                new Card("Last1", 5, 2),
            };
        }

        int _SelectedMission;
        public int SelectedMission
        {
            get
            {
                return _SelectedMission;
            }
            set
            {
                if (_SelectedMission != value)
                {
                    _SelectedMission = value;
                    RaisePropertyChanged("SelectedMission");
                }
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
