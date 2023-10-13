﻿using Clinic.Application.Dtos.Exam.Response;
using Clinic.Application.UseCase.Commons.Bases;
using MediatR;

namespace Clinic.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery
{
    public class GetExamByIdQuery:IRequest<BaseResponse<GetExamByIdResponseDto>>
    {
        public int ExamId { get; set; }
    }
}
