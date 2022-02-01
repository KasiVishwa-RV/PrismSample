using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismApp2.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {
        public ViewAViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
