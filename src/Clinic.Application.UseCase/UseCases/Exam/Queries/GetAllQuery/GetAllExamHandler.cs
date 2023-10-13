using Clinic.Application.Dtos.Exam.Response;
using Clinic.Application.Interface.Interfaces;
using Clinic.Application.UseCase.Commons.Bases;
using Clinic.Utilities.Constants;
using MediatR;

namespace Clinic.Application.UseCase.UseCases.Exam.Queries.GetAllQuery
{
    public class GetAllExamHandler : IRequestHandler<GetAllExamQuery, BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllExamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<IEnumerable<GetAllExamResponseDto>>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllExamResponseDto>>();

            try
            {
                var exams = await _unitOfWork.Exam.GetAllExams(StoredProcedures.uspExamList);
                if(exams is not null)
                {
                    response.IsSuccess = true;
                    response.Data= exams;
                    response.Message = GlobalMessages.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                throw;
            }

            return response;    
        }
    }
}
