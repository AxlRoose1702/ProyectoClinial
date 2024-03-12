using AutoMapper;
using MediatR;
using PROYECTOCLINICAL.Application.Dtos.Exam.Response;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using PROYECTOCLINICAL.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Queries.GetByIdQuery
{
    internal class GetExamByIdHandler : IRequestHandler<GetExamByIdQuery, BaseResponse<GetExamByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetExamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        public async Task<BaseResponse<GetExamByIdResponseDto>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetExamByIdResponseDto>();

            try
            {
                var exam = await _unitOfWork.Exam.GetByIdAsync(StoreProcedures.uspExamById, request);
                if(exam == null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }
                response.IsSuccess = true;
                response.Data = _mapper.Map<GetExamByIdResponseDto>(exam);
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
