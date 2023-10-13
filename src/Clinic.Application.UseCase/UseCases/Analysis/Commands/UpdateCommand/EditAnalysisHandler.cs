using AutoMapper;
using Clinic.Application.Interface.Interfaces;
using Clinic.Application.UseCase.Commons.Bases;
using Clinic.Utilities.Constants;
using Clinic.Utilities.HelperExtensions;
using MediatR;
using Entity = Clinic.Domain.Entities;

namespace Clinic.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class EditAnalysisHandler : IRequestHandler<EditAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EditAnalysisHandler( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(EditAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = analysis.GetPropertiesWithValues(); // new { analysis.AnalysisId, analysis.NameAnalysis };
                response.Data = await _unitOfWork.Analysis.ExecAsync(StoredProcedures.uspAnalisysEdit, parameters);

                if(response.Data) 
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_UPDATE ;//"Se ha modificado correctamente";
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
