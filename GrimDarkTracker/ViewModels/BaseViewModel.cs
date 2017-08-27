using GrimDarkTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker.ViewModels
{
    /* All ViewModels will inherit from this class*/
    public class BaseViewModel : ObservableViewModel
    {
        private MainViewModel _mainVM;

        public BaseViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
        }

        public BaseViewModel(RelayMission mainVM)
        {
            _mainVM = mainVM.ViewModel;
        }

        protected void Navigate<T>() where T : BaseViewModel
        {
            //Create new instance of generic type(i.e. Type of view model passed)
            T newVM = (T)Activator.CreateInstance(typeof(T), _mainVM);
            //Change MainViewModels ViewModel to the new instance
            _mainVM.Navigate<T>(newVM);
        }

        protected void Navigate<T>(RelayMission relayParam) where T : BaseViewModel
        {
            //Create new instance of generic type(i.e. Type of view model passed)
            T newVM = (T)Activator.CreateInstance(typeof(T), new object[] { relayParam });
            //Change MainViewModels ViewModel to the new instance
            _mainVM.Navigate<T>(newVM);
        }
    }
}
