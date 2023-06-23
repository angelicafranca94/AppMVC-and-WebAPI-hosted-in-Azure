using FiapSchoolSystem.Client.Contracts;
using FiapSchoolSystem.Client.Models;

namespace FiapSchoolSystem.Client.Services;

public class AlunoService : BaseService, IAlunoService
{
    private readonly IHttpClientFactory _clientFactory;

    public AlunoService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<T> CreateAlunoAsync<T>(AlunoViewModel model)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = model,
            Url = SD.FiapSystemAPIBase + "/api/alunos"
        });
    }

    public async Task<T> DeleteAlunoAsync<T>(int id)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.FiapSystemAPIBase + "/api/alunos/" + id
        });
    }

    public async Task<T> GetAllAlunosAsync<T>()
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.FiapSystemAPIBase + "/api/alunos"
        });
    }

    public async Task<T> GetAlunoByIdAsync<T>(int id)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.FiapSystemAPIBase + "/api/alunos/" + id
        });
    }

    public async Task<T> UpdateAlunoAsync<T>(int id, AlunoViewModel model)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data = model,
            Url = SD.FiapSystemAPIBase + "/api/alunos/" + id
        });
    }
}
