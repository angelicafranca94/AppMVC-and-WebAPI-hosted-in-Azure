namespace FiapSchoolSystem.Infra.Builder;

public static class AlunoTurmaQueryBuilder
{
    public const string GetAll = @"SELECT DISTINCT Turma_Id FROM Aluno_Turma";
    public const string GetAllAlunos = @"SELECT DISTINCT Aluno_Id FROM Aluno_Turma Where Turma_Id = @Id";
    public const string Insert = @"INSERT INTO Aluno_Turma VALUES (@AlunoId, @TurmaId)";
    public const string Delete = @"DELETE FROM Aluno_Turma WHERE Aluno_Id = @AlunoId AND Turma_Id = @TurmaId ";
    public const string GetAlunoTurma = @"Select *FROM Aluno_Turma WHERE Aluno_Id = @AlunoId AND Turma_Id = @TurmaId";
    
}
