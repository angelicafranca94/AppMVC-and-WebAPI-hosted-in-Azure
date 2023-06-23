using FiapSchoolSystem.Client.Contracts;
using FiapSchoolSystem.Client.Models;
using FiapSchoolSystem.Client.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FiapSchoolSystem.Client.Controllers;
public class AlunoController : Controller
{
	private readonly IAlunoService _alunoService;
	public AlunoController(IAlunoService alunoService)
	{
		_alunoService = alunoService;
	}

	public async Task<IActionResult> Index()
	{
		List<AlunoViewModel> list = new List<AlunoViewModel>();
		var response = await _alunoService.GetAllAlunosAsync<ResponseDto>();
		if (response != null && response.IsSuccess)
		{
			list = JsonConvert.DeserializeObject<List<AlunoViewModel>>(Convert.ToString(response.Result));
		}
		return View(list);
	}

	public async Task<IActionResult> CreateAluno()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> CreateAluno(AlunoViewModel model)
	{
		if (ModelState.IsValid)
		{

			var response = await _alunoService.CreateAlunoAsync<ResponseDto>(model);
			if (response != null && response.IsSuccess)
			{
				return RedirectToAction(nameof(Index));
			}
		}
		return View(model);
	}

	public async Task<IActionResult> UpdateAluno(int id)
	{
		var response = await _alunoService.GetAlunoByIdAsync<ResponseDto>(id);
		if (response != null && response.IsSuccess)
		{
			AlunoViewModel model = JsonConvert.DeserializeObject<AlunoViewModel>(Convert.ToString(response.Result));
			return View(model);
		}
		return NotFound();
	}

	[HttpPost]
	public async Task<IActionResult> UpdateAluno(AlunoViewModel model)
	{
		if (ModelState.IsValid)
		{
			var response = await _alunoService.UpdateAlunoAsync<ResponseDto>(model.Id, model);
			if (response != null && response.IsSuccess)
			{
				return RedirectToAction(nameof(Index));
			}
		}
		return View(model);
	}

	
	public async Task<IActionResult> DeleteAluno(int id)
	{
		var response = await _alunoService.GetAlunoByIdAsync<ResponseDto>(id);
		if (response != null && response.IsSuccess)
		{
			AlunoViewModel model = JsonConvert.DeserializeObject<AlunoViewModel>(Convert.ToString(response.Result));
			return View(model);
		}
		return NotFound();
	}

	[HttpPost]
	public async Task<IActionResult> DeleteAluno(AlunoViewModel model)
	{
		var response = await _alunoService.DeleteAlunoAsync<ResponseDto>(model.Id);
		if (response.IsSuccess)
		{
			return RedirectToAction(nameof(Index));
		}
		return View(model);
	}
}