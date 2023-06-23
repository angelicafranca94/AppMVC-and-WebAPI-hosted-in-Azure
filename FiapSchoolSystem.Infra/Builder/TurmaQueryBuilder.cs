namespace FiapSchoolSystem.Infra.Builder;

public static class TurmaQueryBuilder
{
    public const string GetAll = @"SELECT * FROM Turma";

    public const string GetById = @"SELECT * FROM Turma where Id = @id";
    public const string Insert = @"INSERT INTO Turma VALUES (@CursoId, @Nome, @Ano)";
    public const string Update = @"Update Turma SET CursoId = @CursoId, Nome = @Nome, Ano = @Ano WHERE Id = @Id";
    public const string Delete = @"DELETE FROM Turma WHERE Id = @Id";
}
