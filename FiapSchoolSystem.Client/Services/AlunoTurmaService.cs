using FiapSchoolSystem.Client.Contracts;
using FiapSchoolSystem.Client.Models;
using FiapSchoolSystem.Client.Models.Dto;
using Newtonsoft.Json;

namespace FiapSchoolSystem.Client.Services;

public class AlunoTurmaService : BaseService, IAlunoTurmaService
{
    private readonly IHttpClientFactory _clientFactory;

    public AlunoTurmaService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<T> CreateAlunoTurmaAsync<T>(AlunoTurmaViewModel model)
    {
        var messageReturn = await ExistRelationshipValidateAsync(model);

        if (string.IsNullOrEmpty(messageReturn))
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.FiapSystemAPIBase + "/api/alunosturmas"
            });
        }

        return ErrorTreatment<T>(messageReturn);
    }

    private async Task<string> ExistRelationshipValidateAsync(AlunoTurmaViewModel model)
    {
        string message = string.Empty;
        var response = await GetAlunoTurmaByIdAsync<ResponseDto>(model.Aluno_Id, model.Turma_Id);
        if (response != null && response.IsSuccess)
        {
            message = "Relacionamento existente!";
        }
        return message;
    }

    private static T ErrorTreatment<T>(string messageReturn)
    {
        var dto = new ResponseDto();

        dto.DisplayMessage = "Error";

        var errorMessagesList = dto.ErrorMessages = new List<string>();

        errorMessagesList.Add(messageReturn);

        dto.IsSuccess = false;

        var res = JsonConvert.SerializeObject(dto);
        var apiResponseDto = JsonConvert.DeserializeObject<T>(res);

        return apiResponseDto;
    }

    private async Task<T> GetAlunoTurmaByIdAsync<T>(int alunoId, int turmaId)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.FiapSystemAPIBase + "/api/alunosturmas/" + alunoId + "/" + turmaId
        });
    }

    public async Task<T> GetAllAlunosAsync<T>(int id)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.FiapSystemAPIBase + "/api/alunosturmas/alunos/" + id
        });
    }

    public async Task<T> GetTurmaByIdAsync<T>(int id)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.FiapSystemAPIBase + "/api/turmas/" + id
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


    public async Task<T> GetAllTurmasAsync<T>()
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.FiapSystemAPIBase + "/api/alunosturmas"
        });
    }

    public async Task<T> GetTurmasToDropListAsync<T>()
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.FiapSystemAPIBase + "/api/alunosturmas/relationship"
        });
    }

    public async Task<T> DeleteAlunoTurmaAsync<T>(int alunoId, string turma_id)
    {
        var turmaId = Convert.ToInt32(turma_id);

        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.FiapSystemAPIBase + "/api/alunosturmas/" + alunoId + "/" + turmaId
        });
    }
}
