using AutoMapper;
using Clinic.Application.Interface.Interfaces;
using Clinic.Application.UseCase.Commons.Bases;
using Clinic.Utilities.Constants;
using Clinic.Utilities.HelperExtensions;
using MediatR;
using Entity = Clinic.Domain.Entities;

namespace Clinic.Application.UseCase.UseCases.Exam.Commands.EditCommand
{
    public class EditExamHandler : IRequestHandler<EditExamCommand, BaseResponse<bool>>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public EditExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(EditExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var exam = _mapper.Map<Entity.Exam>(request);
                var parameters = exam.GetPropertiesWithValues();

                response.Data = await _unitOfWork.Exam.ExecAsync(StoredProcedures.uspExamEdit,parameters);

                if(response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_UPDATE;
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                //throw;
            }

            return response;
        }
    }
}
