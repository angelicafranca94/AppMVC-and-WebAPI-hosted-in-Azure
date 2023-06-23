using System.Text.Json;

namespace FiapSchoolSystem.Infra.Model;

public class Turma
{
    public int Id { get; set; }
    public int Curso_Id { get; set; }
    public string Nome { get; set; }
    public int Ano { get; set; }

}
