using AutoMapper;
using MediatR;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using PROYECTOCLINICAL.Domain.Entities;
using PROYECTOCLINICAL.Utilities.Constants;
using Entity = PROYECTOCLINICAL.Domain.Entities

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.TakeExam.Queries.Command.CreateCommand
{
    public class CreateTakeExamHandler : IRequestHandler<CreateTakeExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTakeExamHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(CreateTakeExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var takeExam = _mapper.Map<Entity.TakeExam>(request);
                var takeExamReg = await _unitOfWork.TakeExam.RegisterTakeExam(takeExam);
                foreach (var details in takeExamReg.TakeExamDetail)
                {
                    var newTakeExamDetail = new TakeExamDetail
                    {
                        TakeExamId = (int)takeExamReg.TakeExamId!,
                        ExamId = details.ExamId,
                        AnalysisId = details.AnalysisId,
                    };

                    await _unitOfWork.TakeExam.RegisterTakeExamDetail(newTakeExamDetail);
                }
                transaction.Complete();
                response.IsSuccess = true;
                response.Message = GlobalMessage.MESSAGE_SAVE;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
