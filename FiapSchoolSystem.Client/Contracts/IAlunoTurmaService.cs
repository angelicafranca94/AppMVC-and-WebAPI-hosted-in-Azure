using FiapSchoolSystem.Client.Models;

namespace FiapSchoolSystem.Client.Contracts;

public interface IAlunoTurmaService : IBaseService
{
    Task<T> GetAllTurmasAsync<T>();

    Task<T> GetAllAlunosAsync<T>(int id);

    Task<T> GetAllAlunosAsync<T>();

    Task<T> CreateAlunoTurmaAsync<T>(AlunoTurmaViewModel model);
    Task<T> GetTurmasToDropListAsync<T>();

    Task<T> GetTurmaByIdAsync<T>(int id);
    Task<T> DeleteAlunoTurmaAsync<T>(int alunoId, string turma_id);
}
