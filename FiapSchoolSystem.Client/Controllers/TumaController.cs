using FiapSchoolSystem.Client.Contracts;
using FiapSchoolSystem.Client.Models;
using FiapSchoolSystem.Client.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FiapSchoolSystem.Client.Controllers;
public class TurmaController : Controller
{
    private readonly ITurmaService _turmaService;
    public TurmaController(ITurmaService turmaService)
    {
        _turmaService = turmaService;
    }

    public async Task<IActionResult> Index()
    {
        List<TurmaViewModel> list = new List<TurmaViewModel>();
        var response = await _turmaService.GetAllTurmasAsync<ResponseDto>();
        if (response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<TurmaViewModel>>(Convert.ToString(response.Result));
        }
        return View(list);
    }

    public async Task<IActionResult> CreateTurma()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTurma(TurmaViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _turmaService.CreateTurmaAsync<ResponseDto>(model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("ErrorMessage", response!.ErrorMessages.First());
        }

        return View(model);
    }

    public async Task<IActionResult> UpdateTurma(int id)
    {
        var response = await _turmaService.GetTurmaByIdAsync<ResponseDto>(id);
        if (response != null && response.IsSuccess)
        {
            TurmaViewModel model = JsonConvert.DeserializeObject<TurmaViewModel>(Convert.ToString(response.Result));
            return View(model);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTurma(TurmaViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _turmaService.UpdateTurmaAsync<ResponseDto>(model.Id, model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        return View(model);
    }

    public async Task<IActionResult> DeleteTurma(int id)
    {
        var response = await _turmaService.GetTurmaByIdAsync<ResponseDto>(id);
        if (response != null && response.IsSuccess)
        {
            TurmaViewModel model = JsonConvert.DeserializeObject<TurmaViewModel>(Convert.ToString(response.Result));
            return View(model);
        }
        return NotFound();
    }


    [HttpPost]
    public async Task<IActionResult> DeleteTurma(TurmaViewModel model)
    {
        var response = await _turmaService.DeleteTurmaAsync<ResponseDto>(model.Id);
        if (response.IsSuccess)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
}