using MediatR;
using PROYECTOCLINICAL.Application.Dtos.TakeExam.Response;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using PROYECTOCLINICAL.Utilities.Constants;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.GetAllQuery
{
    public class GetAllTakeExamHandler : IRequestHandler<GetAllTakeExamQuery, BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public GetAllTakeExamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>> Handle(GetAllTakeExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>();
            try
            {
                var count = await _unitOfWork.TakeExam.CountAsync(TB.TakeExam);
                var takeExams = await _unitOfWork.TakeExam.GetAllTakeExams(StoreProcedures.uspTakeExamList, request);
                if(takeExams is not null)
                {
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.Data = takeExams;
                    response.Message = GlobalMessage.MESSAGE_QUERY;
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
