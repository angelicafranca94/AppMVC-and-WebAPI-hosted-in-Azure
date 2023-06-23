using AutoMapper;
using FiapSchoolSystem.Infra.Dto;
using FiapSchoolSystem.Infra.Model;

namespace FiapSchoolSystem.Infra;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<AlunoDto, Aluno>();
            config.CreateMap<Aluno, AlunoDto>();
            config.CreateMap<TurmaDto, Turma>();
            config.CreateMap<Turma, TurmaDto>();
            config.CreateMap<AlunoTurmaDto, AlunoTurma>();
            config.CreateMap<AlunoTurma, AlunoTurmaDto>();

        });

        return mappingConfig;
    }
}