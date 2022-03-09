using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSampleApp.Model;
using PrismSampleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleApp.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible,IWebApiService
    {
        protected INavigationService NavigationService { get; private set; }


        public List<Result> RecievedContacts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public void IntializingService()
        {
           
        }

        public void Initialize(INavigationParameters parameters)
        {
           
        }
    }
}
