using CandidatesChallenge.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CandidatesChallenge.Services
{
    public interface IApiServices
    {
        Task<Response<object>> GetListAsync<T>(
     string urlBase,
     string servicePrefix,
     string controller);
    }
}
