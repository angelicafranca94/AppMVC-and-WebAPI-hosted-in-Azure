using FiapSchoolSystem.Infra.Dto;
using FiapSchoolSystem.Infra.Model;

namespace FiapSchoolSystem.Infra.Contracts;

public interface IAlunoTurmaRepository
{
    public Task<IEnumerable<int>> GetTurmasAsync();
    public Task<IEnumerable<int>> GetAlunosAsync(int id);
    public Task<AlunoTurma> CreateAlunoTurmaAsync(AlunoTurmaDto alunoTurmaDto);
    public Task<IEnumerable<Turma>> GetTurmasToDropListAsync();
    Task<bool> DeleteAlunoTurmaAsync(int alunoId, int turmaId);
    Task<AlunoTurma> GetAlunoTurmaAsync(int alunoId, int turmaId);
}
