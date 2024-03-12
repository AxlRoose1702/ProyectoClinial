﻿using MediatR;
using PROYECTOCLINICAL.Application.Dtos.Exam.Response;
using PROYECTOCLINICAL.Application.Interface.Interface;
using PROYECTOCLINICAL.Application.UseCase.Commons.Bases;
using PROYECTOCLINICAL.Utilities.Constants;

namespace PROYECTOCLINICAL.Application.UseCase.UseCase.Exam.Queries.GetAllQuery
{
    public class GetAllExamQueryHandler : IRequestHandler<GetAllExamQuery, BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllExamQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllExamResponseDto>>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllExamResponseDto>>();

            try
            {
                var exams = await _unitOfWork.Exam.GetAllExams(StoreProcedures.uspExamList);

                if (exams is not null)
                {
                    response.IsSuccess = true;
                    response.Data = exams;
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