using FiapSchoolSystem.Infra.Contracts;
using FiapSchoolSystem.Infra.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FiapSchoolSystem.API.Controllers;

[Route("api/turmas")]
[ApiController]
public class TurmaController : ControllerBase
{
   
    protected ResponseDto _response;
    private readonly ITurmaRepository _turmaRepository;

    public TurmaController(ITurmaRepository turmaRepository)
    {
        _turmaRepository = turmaRepository;
        _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> GetAll()
    {
        try
        {
            var turmas = await _turmaRepository.GetTurmasAsync();
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

    [HttpGet("{id}")]
    public async Task<object> GetById(int id)
    {
        try
        {
            var turma = await _turmaRepository.GetTurmaAsync(id);
            _response.Result = turma;
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
    public async Task<object> Post([FromBody] TurmaDto turmaDto)
    {
        try
        {
            var createdTurma = await _turmaRepository.CreateTurmaAsync(turmaDto);
            _response.Result = createdTurma;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                 = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpPut("{id}")]
    public async Task<object> Put(int id, [FromBody] TurmaDto turmaDto)
    {
        try
        {
            var Turma = await _turmaRepository.GetTurmaAsync(id);
            if (Turma is null)
                return NotFound();

            var updatedTurma = await _turmaRepository.UpdateTurmaAsync(id, turmaDto);
            _response.Result = updatedTurma;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages
                 = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpDelete("{id}")]
    public async Task<object> Delete(int id)
    {
        try
        {
            var Turma = await _turmaRepository.GetTurmaAsync(id);
            if (Turma is null)
                return NotFound();

            bool isSuccess = await _turmaRepository.DeleteTurmaAsync(id);
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
}
