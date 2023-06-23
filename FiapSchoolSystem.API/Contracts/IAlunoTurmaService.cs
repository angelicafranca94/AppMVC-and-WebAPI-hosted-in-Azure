using FiapSchoolSystem.Infra.Dto;
using FiapSchoolSystem.Infra.Model;

namespace FiapSchoolSystem.API.Contracts;

public interface IAlunoTurmaService
{
    Task<IEnumerable<Aluno>> GetAlunosAsync(int id);
    Task<IEnumerable<Turma>> GetTurmasAsync();

    Task<IEnumerable<Turma>> GetTurmasToDropListAsync();
    Task<AlunoTurma> CreateAlunoTurmaAsync(AlunoTurmaDto alunoTurmaDto);
    Task<Turma> GetTurmaByIdAsync(int id);
    Task<bool> DeleteAlunoTurmaAsync(int alunoId, int turmaId);
    Task<AlunoTurma> GetAlunoTurmaAsync(int alunoId, int turmaId);
}
