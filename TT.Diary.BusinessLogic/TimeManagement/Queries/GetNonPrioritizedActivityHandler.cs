using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetNonPrioritizedActivityHandler : IRequestHandler<GetNonPrioritizedActivityQuery, List<NonPrioritizedActivity>>
    {
        private readonly NonPrioritizedActivityRepository _repository;

        public GetNonPrioritizedActivityHandler(NonPrioritizedActivityRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<NonPrioritizedActivity>> Handle(GetNonPrioritizedActivityQuery request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetList(request.UserId));
        }
    }
}