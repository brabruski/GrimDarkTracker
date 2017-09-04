using GrimDarkTracker.ViewModels.MissionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace GrimDarkTracker.Views
{
    /// <summary>
    /// Interaction logic for EternalView.xaml
    /// </summary>
    public partial class EternalView : UserControl
    {
        public EternalView()
        {
            InitializeComponent();
        }

        private void UpdateObjectives_Click(object sender, RoutedEventArgs e)
        {
            EternalViewModel.CalculateTotalObjectivePoints();
        }
    }
}
