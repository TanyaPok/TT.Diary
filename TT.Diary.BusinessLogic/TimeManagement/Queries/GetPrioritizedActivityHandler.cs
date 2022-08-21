using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetPrioritizedActivityHandler : IRequestHandler<GetPrioritizedActivityQuery, List<PrioritizedActivity>>
    {
        private readonly PrioritizedActivityRepository _repository;

        public GetPrioritizedActivityHandler(PrioritizedActivityRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<PrioritizedActivity>> Handle(GetPrioritizedActivityQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetList(request.UserId, request.StartDate, request.FinishDate));
        }
    }
}