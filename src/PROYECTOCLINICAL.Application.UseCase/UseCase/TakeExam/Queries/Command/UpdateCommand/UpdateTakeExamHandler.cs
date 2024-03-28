using AutoMapper;
using MediatR;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using PROYECTOCLINICAL.Domain.Entities;
using PROYECTOCLINICAL.Utilities.Constants;
using Entity = PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.Command.UpdateCommand
{
    public class UpdateTakeExamHandler : IRequestHandler<UpdateTakeExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTakeExamHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateTakeExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var takeExam = _mapper.Map<Entity.TakeExam>(request);
                await _unitOfWork.TakeExam.EditTakeExam(takeExam);

                foreach (var detail in request.TakeExamDetails)
                {
                    var editTakeExamDetail = new TakeExamDetail
                    {
                        ExamId = detail.ExamId,
                        AnalysisId = detail.AnalysisId,
                        TakeExamDetailId = detail.TakeExamDetailId,
                    };
                    await _unitOfWork.TakeExam.EditTakeExamdetail(editTakeExamDetail);
                }
                transaction.Complete();
                response.IsSuccess = true;
                response.Message = GlobalMessage.MESSAGE_UPDATE;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
