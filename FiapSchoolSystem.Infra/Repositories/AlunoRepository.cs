using AutoMapper;
using Dapper;
using FiapSchoolSystem.Infra.Builder;
using FiapSchoolSystem.Infra.Contracts;
using FiapSchoolSystem.Infra.Dto;
using FiapSchoolSystem.Infra.Model;
using System.Data;

namespace FiapSchoolSystem.Infra.Repositories;

public class AlunoRepository : IAlunoRepository
{

    private readonly IDbConnection _dbConnection;
    private IMapper _mapper;

    public AlunoRepository(IDbConnection dbConnection, IMapper mapper)
    {
        _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        _mapper = mapper;
    }

    public async Task<Aluno> GetAlunoAsync(int id)
    {
        var parameters = new { id = id };
        var result = await _dbConnection.QueryAsync<Aluno>(AlunoQueryBuilder.GetById, parameters);

        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<Aluno>> GetAlunosAynsc()
    {
        return await _dbConnection.QueryAsync<Aluno>(AlunoQueryBuilder.GetAll);
    }

    public async Task<Aluno> CreateAlunoAsync(AlunoDto alunoDto)
    {
        Aluno aluno = _mapper.Map<AlunoDto, Aluno>(alunoDto);

        var parameters = new { Nome = aluno.Nome, Usuario = aluno.Usuario, Senha = aluno.Senha };
        
        await _dbConnection.ExecuteAsync(AlunoQueryBuilder.Insert, parameters);

        return aluno;

    }

    public async Task<Aluno> UpdateAlunoAsync(int id, AlunoDto alunoDto)
    {
        Aluno aluno = _mapper.Map<AlunoDto, Aluno>(alunoDto);

        var parameters = new { Nome = aluno.Nome, Usuario = aluno.Usuario, Senha = aluno.Senha,Id = id };

        await _dbConnection.ExecuteAsync(AlunoQueryBuilder.Update, parameters);

        return aluno;
    }

    public async Task<bool> DeleteAlunoAsync(int id)
    {
        var parameters = new { Id = id };

        var affectedRows = await _dbConnection.ExecuteAsync(AlunoQueryBuilder.Delete, parameters);

        return affectedRows > 0;
    }
}
