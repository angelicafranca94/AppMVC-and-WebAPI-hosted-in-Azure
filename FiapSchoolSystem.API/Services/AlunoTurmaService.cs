using FiapSchoolSystem.API.Contracts;
using FiapSchoolSystem.Infra.Contracts;
using FiapSchoolSystem.Infra.Dto;
using FiapSchoolSystem.Infra.Model;

namespace FiapSchoolSystem.API.Services;

public class AlunoTurmaService: IAlunoTurmaService
{
    private readonly IAlunoRepository _alunoRepository;
    private readonly ITurmaRepository _turmaRepository;
    private readonly IAlunoTurmaRepository _alunoTurmaRepository;
    public AlunoTurmaService(IAlunoRepository alunoRepository,
        ITurmaRepository turmaRepository,
        IAlunoTurmaRepository alunoTurmaRepository)
    {
        _alunoRepository = alunoRepository;
        _turmaRepository = turmaRepository;
        _alunoTurmaRepository = alunoTurmaRepository;
    }

    public async Task<IEnumerable<Turma>> GetTurmasToDropListAsync()
    {
        return await _alunoTurmaRepository.GetTurmasToDropListAsync();
    }
    public async Task<IEnumerable<Aluno>> GetAlunosAsync(int id)
    {
        var alunos = await _alunoTurmaRepository.GetAlunosAsync(id);

        return await ConvertToListAlunosAsync(alunos);
    }

    private async Task<IEnumerable<Aluno>> ConvertToListAlunosAsync(IEnumerable<int> idAlunos)
    {
        List<Aluno> listAluno = new List<Aluno>();

        foreach (var item in idAlunos)
        {
            var aluno = await _alunoRepository.GetAlunoAsync(item);
            listAluno.Add(aluno);
        }

        return listAluno;
    }

    public async Task<IEnumerable<Turma>> GetTurmasAsync()
    {
        var turmas = await _alunoTurmaRepository.GetTurmasAsync();

        return await ConvertToListTurmasAsync(turmas);
    }

    private async Task<IEnumerable<Turma>> ConvertToListTurmasAsync(IEnumerable<int> idTurmas)
    {
        List<Turma> listTurma = new List<Turma>();

        foreach (var item in idTurmas)
        {
            var turma = await _turmaRepository.GetTurmaAsync(item);
            listTurma.Add(turma);
        }

        return listTurma;
    }

    public async Task<AlunoTurma> CreateAlunoTurmaAsync(AlunoTurmaDto alunoTurmaDto)
    {
       return await _alunoTurmaRepository.CreateAlunoTurmaAsync(alunoTurmaDto);
    }

    public async Task<Turma> GetTurmaByIdAsync(int id)
    {
        return await _turmaRepository.GetTurmaAsync(id);
    }

    public async Task<bool> DeleteAlunoTurmaAsync(int alunoId, int turmaId)
    {
        return await _alunoTurmaRepository.DeleteAlunoTurmaAsync(alunoId, turmaId);
    }

    public async Task<AlunoTurma> GetAlunoTurmaAsync(int alunoId, int turmaId)
    {
        return await _alunoTurmaRepository.GetAlunoTurmaAsync(alunoId, turmaId);
    }
}
