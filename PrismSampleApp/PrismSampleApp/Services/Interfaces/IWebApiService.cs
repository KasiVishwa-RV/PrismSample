using PrismSampleApp.Model;
using System.Collections.Generic;

namespace PrismSampleApp.Services.Interfaces
{
    public interface IWebApiService
    { 
       List<Result> RecievedContacts { get; set; }   
       void IntializingService();
    }
}