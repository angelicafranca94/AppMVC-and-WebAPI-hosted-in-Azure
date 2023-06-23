using FiapSchoolSystem.Infra.Contracts;
using FiapSchoolSystem.Infra.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FiapSchoolSystem.API.Controllers;

[Route("api/alunos")]
[ApiController]
public class AlunoController : ControllerBase
{
   
    protected ResponseDto _response;
    private readonly IAlunoRepository _alunoRepository;

    public AlunoController(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
        _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> GetAll()
    {
        try
        {
            var alunos = await _alunoRepository.GetAlunosAynsc();
            _response.Result = alunos;
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
            var aluno = await _alunoRepository.GetAlunoAsync(id);
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
    public async Task<object> Post([FromBody] AlunoDto alunoDto)
    {
        try
        {
            var createdAluno = await _alunoRepository.CreateAlunoAsync(alunoDto);
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

    [HttpPut("{id}")]
    public async Task<object> Put(int id, [FromBody] AlunoDto alunoDto)
    {
        try
        {
            var aluno = await _alunoRepository.GetAlunoAsync(id);
            if (aluno is null)
                return NotFound();

            var updatedAluno = await _alunoRepository.UpdateAlunoAsync(id, alunoDto);
            _response.Result = updatedAluno;
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
            var aluno = await _alunoRepository.GetAlunoAsync(id);
            if (aluno is null)
                return NotFound();

            bool isSuccess = await _alunoRepository.DeleteAlunoAsync(id);
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
