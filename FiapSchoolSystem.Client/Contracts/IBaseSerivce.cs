using FiapSchoolSystem.Client.Models;
using FiapSchoolSystem.Client.Models.Dto;

namespace FiapSchoolSystem.Client.Contracts;

public interface IBaseService : IDisposable
{
    ResponseDto responseModel { get; set; }
 
    Task<T> SendAsync<T>(ApiRequest apiRequest);
}
