using GrimDarkTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GrimDarkTracker.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        //Relay command to call 'ToBattleSelect' function
        public ICommand SwitchBattleSelect
        {
            get { return new RelayCommand(ToBattleSelect); }
        }

        public HomeViewModel(MainViewModel main) : base(main)
        {

        }        

        //Calling ViewModel function. Passed ViewModel Type
        public void ToBattleSelect(object param)
        {
            Navigate<BattleSelectViewModel>();
        }
    }
}
