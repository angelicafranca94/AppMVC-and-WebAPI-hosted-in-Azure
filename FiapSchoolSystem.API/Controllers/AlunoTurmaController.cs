using FiapSchoolSystem.API.Contracts;
using FiapSchoolSystem.Infra.Contracts;
using FiapSchoolSystem.Infra.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FiapSchoolSystem.API.Controllers;

[Route("api/alunosturmas")]
[ApiController]
public class AlunoTurmaController : ControllerBase
{
    protected ResponseDto _response;
    private readonly IAlunoTurmaService _alunoTurmaService;

    public AlunoTurmaController(
        IAlunoTurmaService alunoTurmaService)
    {
        _alunoTurmaService = alunoTurmaService;
        _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> GetAll()
    {
        try
        {
            var turmas = await _alunoTurmaService.GetTurmasAsync();
            _response.Result = turmas;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                 = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpGet("relationship")]
    public async Task<object> GetAllTurmasToDropList()
    {
        try
        {
            var turmas = await _alunoTurmaService.GetTurmasToDropListAsync();
            _response.Result = turmas;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                 = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpGet("alunos/{id}")]
    public async Task<object> GetById(int id)
    {
        try
        {
            var aluno = await _alunoTurmaService.GetAlunosAsync(id);
            _response.Result = aluno;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                 = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] AlunoTurmaDto alunoTurmaDto)
    {
        try
        {
            var createdAluno = await _alunoTurmaService.CreateAlunoTurmaAsync(alunoTurmaDto);
            _response.Result = createdAluno;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                 = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpDelete("{alunoId}/{turmaId}")]
    public async Task<object> Delete(int alunoId, int turmaId)
    {
        try
        {
            bool isSuccess = await _alunoTurmaService.DeleteAlunoTurmaAsync(alunoId, turmaId);
            _response.Result = isSuccess;

        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                 = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpGet("{alunoId}/{turmaId}")]
    public async Task<object> Get(int alunoId, int turmaId)
    {
        try
        {
            var alunoTurma = await _alunoTurmaService.GetAlunoTurmaAsync(alunoId, turmaId);
            _response.Result = alunoTurma;

        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                 = new List<string>() { ex.ToString() };
        }
        return _response;
    }
}
