using BlazorCRUDApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUDApp.Shared.Interfaces
{
    public interface IHttpService
    {
        Task<ServiceResponse<T>> GetAsync<T>(string url);
    }
}
