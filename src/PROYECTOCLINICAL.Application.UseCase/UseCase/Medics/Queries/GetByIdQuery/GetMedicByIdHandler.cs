using AutoMapper;
using MediatR;
using PROYECTOCLINICAL.Application.Dtos.Medic.Response;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using PROYECTOCLINICAL.Utilities.Constants;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Queries.GetByIdQuery
{
    public class GetMedicByIdHandler : IRequestHandler<GetMedicByIdQuery, BaseResponse<GetMedicByIdResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMedicByIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<GetMedicByIdResponseDto>> Handle(GetMedicByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetMedicByIdResponseDto>();

            try
            {
                var medic = await _unitOfWork.Medic.GetByIdAsync(StoreProcedures.uspMedicById, request);
                if(medic is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }
                response.IsSuccess = true;
                response.Data = _mapper.Map<GetMedicByIdResponseDto>(medic);
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