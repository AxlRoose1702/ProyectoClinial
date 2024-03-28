using AutoMapper;
using MediatR;
using PROYECTOCLINICAL.Application.Dtos.TakeExam.Response;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using PROYECTOCLINICAL.Utilities.Constants;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.GetByIdQuery
{
    public class GetTakeExamByIdHandler : IRequestHandler<GetTakeExamByIdQuery, BasePaginationResponse<IEnumerable<GetTakeExamByIdResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetTakeExamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetTakeExamByIdResponseDto>>> Handle(GetTakeExamByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetTakeExamByIdResponseDto>>();

            try
            {
                var takeExams = await _unitOfWork.TakeExam.GetTakeExamById(request.TakeExamId);
                takeExams.TakeExamDetail = await _unitOfWork.TakeExam.GetTakeExamDetailByTakeExamId(request.TakeExamId);
                response.IsSuccess = true;
                response.Data = _mapper.Map <IEnumerable<GetTakeExamByIdResponseDto>>(takeExams);
                response.Message = GlobalMessage.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
