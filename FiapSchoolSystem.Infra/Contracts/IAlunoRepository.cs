using FiapSchoolSystem.Infra.Dto;
using FiapSchoolSystem.Infra.Model;


namespace FiapSchoolSystem.Infra.Contracts;

public interface IAlunoRepository
{
    public Task<IEnumerable<Aluno>> GetAlunosAynsc();
    public Task<Aluno> GetAlunoAsync(int id);
    public Task<Aluno> CreateAlunoAsync(AlunoDto aluno);
    public Task<Aluno> UpdateAlunoAsync(int id, AlunoDto aluno);
    public Task<bool> DeleteAlunoAsync(int id);

}
