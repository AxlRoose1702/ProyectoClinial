using AutoMapper;
using MediatR;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using PROYECTOCLINICAL.Utilities.Constants;
using PROYECTOCLINICAL.Utilities.HelperExtensions;
using Entity = PROYECTOCLINICAL.Domain.Entities;
namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Medics.Commands.CreateCommand
{
    public class CreateMedicHandler : IRequestHandler<CreateMedicCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var medic = _mapper.Map<Entity.Medic>(request);
                var parameters = medic.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Medic.ExecAsync(StoreProcedures.uspMedicRegister, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_SAVE;
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
