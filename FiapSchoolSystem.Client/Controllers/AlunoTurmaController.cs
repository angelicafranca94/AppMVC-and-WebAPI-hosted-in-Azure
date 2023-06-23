using FiapSchoolSystem.Client.Contracts;
using FiapSchoolSystem.Client.Models;
using FiapSchoolSystem.Client.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FiapSchoolSystem.Client.Controllers;
public class AlunoTurmaController : Controller
{
    private readonly IAlunoTurmaService _alunoTurmaService;
    public AlunoTurmaController(IAlunoTurmaService alunoTurmaService)
    {
        _alunoTurmaService = alunoTurmaService;
    }

    public async Task<IActionResult> Index()
    {
        List<TurmaViewModel> list = new List<TurmaViewModel>();
        var response = await _alunoTurmaService.GetAllTurmasAsync<ResponseDto>();
        if (response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<TurmaViewModel>>(Convert.ToString(response.Result));
        }
        return View(list);
    }

    public async Task<IActionResult> ListAluno(int id)
    {
        List<AlunoViewModel> list = new List<AlunoViewModel>();
        var response = await _alunoTurmaService.GetAllAlunosAsync<ResponseDto>(id);
        if (response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<AlunoViewModel>>(Convert.ToString(response.Result));
        }


        return View(list);
    }

    public async Task<IActionResult> CreateRelationship()
    {
        List<TurmaViewModel> listTurma = new List<TurmaViewModel>();
        var responseTurma = await _alunoTurmaService.GetTurmasToDropListAsync<ResponseDto>();
        if (responseTurma != null && responseTurma.IsSuccess)
        {
            listTurma = JsonConvert.DeserializeObject<List<TurmaViewModel>>(Convert.ToString(responseTurma.Result));
        }

        List<AlunoViewModel> listAluno = new List<AlunoViewModel>();
        var response = await _alunoTurmaService.GetAllAlunosAsync<ResponseDto>();
        if (response != null && response.IsSuccess)
        {
            listAluno = JsonConvert.DeserializeObject<List<AlunoViewModel>>(Convert.ToString(response.Result));
        }

        var model = new AlunoTurmaViewModel
        {
            Turmas = listTurma,
            Alunos = listAluno

        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRelationship(AlunoTurmaViewModel model)
    {

        var response = await _alunoTurmaService.CreateAlunoTurmaAsync<ResponseDto>(model);
        if (response != null && response.IsSuccess)
        {
            return RedirectToAction(nameof(Index));
        }

        ModelState.AddModelError("ErrorMessage", response!.ErrorMessages.First());

         model = new AlunoTurmaViewModel
        {
            Turmas = new List<TurmaViewModel> { },
            Alunos = new List<AlunoViewModel> { }

         };

        return View(model);
    }

    public async Task<IActionResult> UpdateRelationship(int id)
    {

        List<TurmaViewModel> listTurma = new List<TurmaViewModel>();
        TurmaViewModel turma = new();
        var response = await _alunoTurmaService.GetTurmaByIdAsync<ResponseDto>(id);
        if (response != null && response.IsSuccess)
        {
            turma = JsonConvert.DeserializeObject<TurmaViewModel>(Convert.ToString(response.Result));
            listTurma.Add(turma);

        }

        List<AlunoViewModel> listAluno = new List<AlunoViewModel>();
        var responseAlunos = await _alunoTurmaService.GetAllAlunosAsync<ResponseDto>();
        if (responseAlunos != null && responseAlunos.IsSuccess)
        {
            listAluno = JsonConvert.DeserializeObject<List<AlunoViewModel>>(Convert.ToString(responseAlunos.Result));

        }



        var model = new AlunoTurmaViewModel
        {
            Turmas = listTurma,
            Alunos = listAluno

        };

        return View(model);
    }


    public async Task<IActionResult> DeleteRelationship(int id, string turma_id)
    {

        var response = await _alunoTurmaService.DeleteAlunoTurmaAsync<ResponseDto>(id, turma_id);
        if (response.IsSuccess)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

}
