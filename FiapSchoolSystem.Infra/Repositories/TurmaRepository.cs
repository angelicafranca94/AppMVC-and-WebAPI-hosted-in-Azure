using AutoMapper;
using Dapper;
using FiapSchoolSystem.Infra.Builder;
using FiapSchoolSystem.Infra.Contracts;
using FiapSchoolSystem.Infra.Dto;
using FiapSchoolSystem.Infra.Model;
using System.Data;

namespace FiapSchoolSystem.Infra.Repositories;

public class TurmaRepository : ITurmaRepository
{

    private readonly IDbConnection _dbConnection;
    private IMapper _mapper;

    public TurmaRepository(IDbConnection dbConnection, IMapper mapper)
    {
        _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        _mapper = mapper;
    }

    public async Task<Turma> GetTurmaAsync(int id)
    {
        var parameters = new { id = id };
        var result = await _dbConnection.QueryAsync<Turma>(TurmaQueryBuilder.GetById, parameters);

        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<Turma>> GetTurmasAsync()
    {
        return await _dbConnection.QueryAsync<Turma>(TurmaQueryBuilder.GetAll);
    }

    public async Task<Turma> CreateTurmaAsync(TurmaDto turmaDto)
    {

        Turma Turma = _mapper.Map<TurmaDto, Turma>(turmaDto);

        var parameters = new { CursoId = turmaDto.CursoId, Nome = Turma.Nome, Ano = turmaDto.Ano };

        await _dbConnection.ExecuteAsync(TurmaQueryBuilder.Insert, parameters);

        return Turma;

    }

    public async Task<Turma> UpdateTurmaAsync(int id, TurmaDto turmaDto)
    {
        Turma Turma = _mapper.Map<TurmaDto, Turma>(turmaDto);

        var parameters = new { CursoId = turmaDto.CursoId, Nome = turmaDto.Nome, Ano = turmaDto.Ano, Id = id};

        await _dbConnection.ExecuteAsync(TurmaQueryBuilder.Update, parameters);

        return Turma;
    }

    public async Task<bool> DeleteTurmaAsync(int id)
    {
        var parameters = new { Id = id };

        var affectedRows = await _dbConnection.ExecuteAsync(TurmaQueryBuilder.Delete, parameters);

        return affectedRows > 0;
    }

}
