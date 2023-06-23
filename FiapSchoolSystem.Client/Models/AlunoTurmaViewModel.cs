using Microsoft.AspNetCore.Mvc.Rendering;

namespace FiapSchoolSystem.Client.Models;

public class AlunoTurmaViewModel
{
    public int Turma_Id { get; set; }
    public int Aluno_Id { get; set; }

    public List<TurmaViewModel> Turmas { get; set; }
    public List<AlunoViewModel> Alunos { get; set; }

    public string? ErrorMessage { get; set; }
}
