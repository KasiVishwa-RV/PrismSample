using PrismSampleApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PrismSampleApp.Services.Interfaces
{
    public interface IWebApiService
    {
    Task<List<Result>> IntializingService();
    }
}