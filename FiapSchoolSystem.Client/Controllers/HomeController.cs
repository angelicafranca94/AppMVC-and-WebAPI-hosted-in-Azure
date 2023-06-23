using FiapSchoolSystem.Client.Contracts;
using FiapSchoolSystem.Client.Models;
using FiapSchoolSystem.Client.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FiapSchoolSystem.Client.Controllers;
public class HomeController : Controller
{
    private readonly IAlunoService _alunoService;
    public HomeController(IAlunoService alunoService)
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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
