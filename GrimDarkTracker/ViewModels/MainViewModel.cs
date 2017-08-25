using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimDarkTracker.ViewModels
{
    /* ViewModel that can be used to swith between other views using RelayCommands */
    class MainViewModel : ObservableViewModel
    {
        public BaseViewModel Container { get; set; }

        public MainViewModel()
        {
            Navigate<HomeViewModel>(new HomeViewModel(this));
        }

        public void Navigate<T>(BaseViewModel v) where T : BaseViewModel
        {
            Container = v as T;
            Console.WriteLine(Container.GetType());
            RaisePropertyChanged("Container");
        }
    }
}
