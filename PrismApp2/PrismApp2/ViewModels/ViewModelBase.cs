using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismApp2.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware
    {
        
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
       
        }

        public void Initialize(INavigationParameters parameters)
        {
            
        }
    }
}
