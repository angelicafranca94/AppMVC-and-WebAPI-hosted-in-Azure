using AutoMapper;
using Dapper;
using FiapSchoolSystem.Infra.Builder;
using FiapSchoolSystem.Infra.Contracts;
using FiapSchoolSystem.Infra.Dto;
using FiapSchoolSystem.Infra.Model;
using System.Data;

namespace FiapSchoolSystem.Infra.Repositories;

public class AlunoTurmaRepository : IAlunoTurmaRepository
{

    private readonly IDbConnection _dbConnection;
    private IMapper _mapper;

    public AlunoTurmaRepository(IDbConnection dbConnection, IMapper mapper)
    {
        _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        _mapper = mapper;
    }

    public async Task<IEnumerable<int>> GetAlunosAsync(int id)
    {
        var parameters = new { Id = id };

        return  await _dbConnection.QueryAsync<int>(AlunoTurmaQueryBuilder.GetAllAlunos, parameters);
    }

    public async Task<IEnumerable<int>> GetTurmasAsync()
    {
        return await _dbConnection.QueryAsync<int>(AlunoTurmaQueryBuilder.GetAll);
    }

    public async Task<IEnumerable<Turma>> GetTurmasToDropListAsync()
    {
        return await _dbConnection.QueryAsync<Turma>(TurmaQueryBuilder.GetAll);
    }

    public async Task<AlunoTurma> CreateAlunoTurmaAsync(AlunoTurmaDto alunoTurmaDto)
    {
        AlunoTurma alunoTurma = _mapper.Map<AlunoTurmaDto, AlunoTurma>(alunoTurmaDto);

        var parameters = new { TurmaId = alunoTurma.Turma_Id, AlunoId = alunoTurma.Aluno_Id };

        await _dbConnection.ExecuteAsync(AlunoTurmaQueryBuilder.Insert, parameters);

        return alunoTurma;

    }

    public async Task<bool> DeleteAlunoTurmaAsync(int alunoId, int turmaId)
    {
        var parameters = new { AlunoId = alunoId, TurmaId = turmaId };

        var affectedRows = await _dbConnection.ExecuteAsync(AlunoTurmaQueryBuilder.Delete, parameters);

        return affectedRows > 0;
    }

    public async Task<AlunoTurma> GetAlunoTurmaAsync(int alunoId, int turmaId)
    {
        var parameters = new { TurmaId = alunoId, AlunoId = turmaId };

        var alunoTurma = await _dbConnection.QueryAsync<AlunoTurma>(AlunoTurmaQueryBuilder.GetAlunoTurma, parameters);

        return alunoTurma.FirstOrDefault();
    }
}
