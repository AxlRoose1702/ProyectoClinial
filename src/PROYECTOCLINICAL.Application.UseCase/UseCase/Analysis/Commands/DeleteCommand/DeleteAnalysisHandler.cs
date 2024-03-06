using MediatR;
using PROYECTOCLINICAL.Application.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;

        public DeleteAnalysisHandler(IAnalysisRepository analysisRepository)
        {
            _analysisRepository = analysisRepository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                response.Data = await _analysisRepository.AnalysisRemove(request.AnalysisId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha eliminado correctamente.";
                }
            } catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
