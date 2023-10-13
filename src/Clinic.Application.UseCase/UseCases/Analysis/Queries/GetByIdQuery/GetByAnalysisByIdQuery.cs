using Clinic.Application.Dtos.Analysis.Response;
using Clinic.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class GetByAnalysisByIdQuery:IRequest<BaseResponse<GetAnalysisByIdResponseDto>>
    {
        public int AnalysisId { get; set; }
    }
}
