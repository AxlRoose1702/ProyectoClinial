using MediatR;
using PROYECTOCLINICAL.Application.Dtos.Medic.Response;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using PROYECTOCLINICAL.Utilities.Constants;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Queries.GetAllQuery
{
    public class GetAllMedicsHandler : IRequestHandler<GetAllMedicQuery, BaseResponse<IEnumerable<GetAllMedicResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMedicsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllMedicResponseDto>>> Handle(GetAllMedicQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllMedicResponseDto>>();

            try
            {
                var medics = await _unitOfWork.Medic.GetAllMedics(StoreProcedures.uspMedicList);
                if(medics is not null)
                {
                    response.IsSuccess = true;
                    response.Data = medics;
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