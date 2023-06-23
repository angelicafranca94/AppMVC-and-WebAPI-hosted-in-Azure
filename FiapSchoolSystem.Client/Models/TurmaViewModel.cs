namespace FiapSchoolSystem.Client.Models;

public class TurmaViewModel
{
    public int Id { get; set; }
    public int Curso_Id { get; set; }
    public string Nome { get; set; }
    public int Ano { get; set; }
    public string? ErrorMessage { get; set; }
}
