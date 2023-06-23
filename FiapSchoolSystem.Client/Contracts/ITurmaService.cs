using FiapSchoolSystem.Client.Models;

namespace FiapSchoolSystem.Client.Contracts;

public interface ITurmaService : IBaseService
{
    Task<T> GetAllTurmasAsync<T>();
    Task<T> GetTurmaByIdAsync<T>(int id);
    Task<T> CreateTurmaAsync<T>(TurmaViewModel model);
    Task<T> UpdateTurmaAsync<T>(int id, TurmaViewModel model);
    Task<T> DeleteTurmaAsync<T>(int id);
}
