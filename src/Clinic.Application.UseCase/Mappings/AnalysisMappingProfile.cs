using AutoMapper;
using Clinic.Application.Dtos.Analysis.Response;
using Clinic.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using Clinic.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using Clinic.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;
using Clinic.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using Clinic.Domain.Entities;

namespace Clinic.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDto>()
                .ForMember(x => x.StateAnalysisStr, x => x.MapFrom(y => y.StateAnalysis == 1 ? "ACTIVO":"INACTIVO"))
                .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();
            CreateMap<EditAnalysisCommand, Analysis>();
            CreateMap<DeleteAnalysisCommand, Analysis>();
            CreateMap<ChangeStateAnalysisCommand, Analysis>();
        }
    }
}
