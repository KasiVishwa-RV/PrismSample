using Flurl.Http;
using Prism.Mvvm;
using PrismSampleApp.Model;
using PrismSampleApp.Services;
using PrismSampleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly:Dependency(typeof(WebApiService))]
namespace PrismSampleApp.Services
{
    public class WebApiService : IWebApiService
    {
        public async Task<List<Result>> IntializingService()
        {
            var content = await "https://randomuser.me/api/?results=50".GetJsonAsync<Root>();
            var RecievedContacts = new List<Result>(content.Results);
            return RecievedContacts;
        }  
    }
}