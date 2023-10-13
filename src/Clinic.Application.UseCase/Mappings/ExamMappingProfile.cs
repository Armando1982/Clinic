using AutoMapper;
using Clinic.Application.Dtos.Exam.Response;
using Clinic.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using Clinic.Application.UseCase.UseCases.Exam.Commands.EditCommand;
using Clinic.Domain.Entities;

namespace Clinic.Application.UseCase.Mappings
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, GetExamByIdResponseDto>().ReverseMap();
            CreateMap<CreateExamCommand, Exam>();
            CreateMap<EditExamCommand, Exam>();
        }
    }
}
