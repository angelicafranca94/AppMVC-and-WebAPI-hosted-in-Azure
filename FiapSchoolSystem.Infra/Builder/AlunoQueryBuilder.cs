namespace FiapSchoolSystem.Infra.Builder;

public static class AlunoQueryBuilder
{
    public const string GetAll = @"SELECT * FROM Aluno";

    public const string GetById = @"SELECT * FROM Aluno where Id = @id";
    public const string Insert = @"INSERT INTO Aluno VALUES (@Nome, @Usuario, @Senha)";
    public const string Update = @"Update Aluno SET Nome = @Nome, Usuario = @Usuario, Senha = @Senha WHERE Id = @Id";
    public const string Delete = @"DELETE FROM Aluno WHERE Id = @Id";
}
