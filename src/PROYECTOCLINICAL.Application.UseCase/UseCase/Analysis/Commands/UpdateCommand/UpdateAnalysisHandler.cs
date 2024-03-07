using AutoMapper;
using MediatR;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using Entity = PROYECTOCLINICAL.Domain.Entities;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        //private readonly IAnalysisRepository _analysisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAnalysisHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            //_analysisRepository = analysisRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = new { analysis.AnalysisId, analysis.Name };

                response.Data = await _unitOfWork.Analysis.ExecAsync("uspAnalysisEdit", parameters);

                if (response.Data) {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado correctamente";
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
