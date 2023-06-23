using FiapSchoolSystem.Infra.Dto;
using FiapSchoolSystem.Infra.Model;


namespace FiapSchoolSystem.Infra.Contracts;

public interface ITurmaRepository
{
    public Task<IEnumerable<Turma>> GetTurmasAsync();
    public Task<Turma> GetTurmaAsync(int id);
    public Task<Turma> CreateTurmaAsync(TurmaDto Turma);
    public Task<Turma> UpdateTurmaAsync(int id, TurmaDto Turma);
    public Task<bool> DeleteTurmaAsync(int id);

}
