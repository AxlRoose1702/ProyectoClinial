using AutoMapper;
using MediatR;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using Entity = PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
    {
        //private readonly IAnalysisRepository _analysisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateAnalysisHandler( IMapper mapper, IUnitOfWork unitOfWork)
        {
            //_analysisRepository = analysisRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameter = new { analysis.Name };

                response.Data = await _unitOfWork.Analysis.ExecAsync("uspAnalysisRegister", parameter);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se registro correctamente";
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
