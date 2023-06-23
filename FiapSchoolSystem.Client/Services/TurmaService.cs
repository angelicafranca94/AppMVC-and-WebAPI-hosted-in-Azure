using FiapSchoolSystem.Client.Contracts;
using FiapSchoolSystem.Client.Models;
using FiapSchoolSystem.Client.Models.Dto;
using Newtonsoft.Json;
using System.Text;

namespace FiapSchoolSystem.Client.Services;

public class TurmaService : BaseService, ITurmaService
{
    private readonly IHttpClientFactory _clientFactory;

    public TurmaService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<T> CreateTurmaAsync<T>(TurmaViewModel model)
    {

        var listMessages = new List<string>();

        listMessages.Add(await NameValidateAsync(model));

        listMessages.Add(YearValidateAync(model));

        if (listMessages.Count == 0)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.FiapSystemAPIBase + "/api/turmas"
            });
        }

        return ErrorTreatment<T>(listMessages);

    }

    private async Task<string> NameValidateAsync(TurmaViewModel model)
    {
        string message = string.Empty;
        var response = await GetAllTurmasAsync<ResponseDto>();
        if (response != null && response.IsSuccess)
        {
            var turmas = JsonConvert.DeserializeObject<List<TurmaViewModel>>(Convert.ToString(response.Result)!);

            if (turmas!.Select(s => s.Nome).Any(x => x.Equals(model.Nome)))
                message = "Nome da turma já existe";

        }
        return message;
    }

    private string YearValidateAync(TurmaViewModel model)
    {
        var messageReturn = string.Empty;

        if (model.Ano < DateTime.Now.Year)
            messageReturn = "Ano da turma não pode ser igual ou menor que ano atual";


        return messageReturn;
    }

    private static T ErrorTreatment<T>(List<string> listMessages)
    {
        var dto = new ResponseDto();

        dto.DisplayMessage = "Error";

        var errorMessagesList = dto.ErrorMessages = new List<string>();

        StringBuilder stringConcatMessages = new StringBuilder();

        foreach (var item in listMessages)
            stringConcatMessages.Append(item).Append(" - ");

        errorMessagesList.Add(stringConcatMessages.ToString());

        dto.IsSuccess = false;

        var res = JsonConvert.SerializeObject(dto);
        var apiResponseDto = JsonConvert.DeserializeObject<T>(res);

        return apiResponseDto;
    }

  

    public async Task<T> DeleteTurmaAsync<T>(int id)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.FiapSystemAPIBase + "/api/turmas/" + id
        });
    }

    public async Task<T> GetAllTurmasAsync<T>()
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.FiapSystemAPIBase + "/api/turmas"
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

    public async Task<T> UpdateTurmaAsync<T>(int id, TurmaViewModel model)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data = model,
            Url = SD.FiapSystemAPIBase + "/api/turmas/" + id
        });
    }
}
