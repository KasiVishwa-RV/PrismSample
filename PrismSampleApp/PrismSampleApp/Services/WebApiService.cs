using Flurl.Http;
using Prism.Mvvm;
using PrismSampleApp.Model;
using PrismSampleApp.Services;
using PrismSampleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

[assembly:Dependency(typeof(WebApiService))]
namespace PrismSampleApp.Services
{
    public class WebApiService : BindableBase, IWebApiService
    {
        public async void IntializingService()
        {
            var content = await "https://randomuser.me/api/?results=50".GetJsonAsync<Root>();
            RecievedContacts = new List<Result>(content.Results);
        }
        private List<Result> _recievedContacts;
        public List<Result> RecievedContacts
        {
            get
            {
                return _recievedContacts;
            }
            set
            {
                SetProperty(ref _recievedContacts, value);
            }

        }
    }
}