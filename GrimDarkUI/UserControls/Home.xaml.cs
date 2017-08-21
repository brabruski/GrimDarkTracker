﻿using System;
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
using GrimDarkUI.ViewModels;
using System.Diagnostics;

namespace GrimDarkUI.UserControls
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void MissionSelectViewBtn_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new MissionSelectViewModel();
            // DataContext = FindResource("MainWindowLink") as ViewModels.MissionSelectViewModel;
            Debug.WriteLine("Button Clicked");
            
        }
    }
}
