using AutoMapper;
using Clinic.Application.Dtos.Analysis.Response;
using Clinic.Application.Interface.Interfaces;
using Clinic.Application.UseCase.Commons.Bases;
using Clinic.Utilities.Constants;
using MediatR;

namespace Clinic.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class GetAnalysisByIdHandler : IRequestHandler<GetByAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
    {
        //private readonly IAnalysisRepository _analysisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAnalysisByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_analysisRepository = analysisRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetByAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalysisByIdResponseDto>();

            try
            {
                var analysis = await _unitOfWork.Analysis.GetByIdAsync(StoredProcedures.uspAnalysisById,request);
                if(analysis is null)
                {
                    response.IsSuccess = false;
                    //response.Data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;//"No se encontrarin Registros";
                }
                else
                {
                    response.IsSuccess = true;
                    response.Data= _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
                    response.Message = GlobalMessages.MESSAGE_QUERY;//"Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
