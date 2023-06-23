using FiapSchoolSystem.Client.Models;

namespace FiapSchoolSystem.Client.Contracts;

public interface IAlunoService : IBaseService
{
    Task<T> GetAllAlunosAsync<T>();
    Task<T> GetAlunoByIdAsync<T>(int id);
    Task<T> CreateAlunoAsync<T>(AlunoViewModel model);
    Task<T> UpdateAlunoAsync<T>(int id, AlunoViewModel model);
    Task<T> DeleteAlunoAsync<T>(int id);
}
