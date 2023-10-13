using AutoMapper;
using Clinic.Application.Interface.Interfaces;
using Clinic.Application.UseCase.Commons.Bases;
using Clinic.Utilities.Constants;
using Clinic.Utilities.HelperExtensions;
using MediatR;
using Entity = Clinic.Domain.Entities;

namespace Clinic.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork =unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = analysis.GetPropertiesWithValues(); //new { analysis.NameAnalysis };
                response.Data = await _unitOfWork.Analysis.ExecAsync(StoredProcedures.uspAnalysisRegister, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_SAVE; //"Se registro corectamente";
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
