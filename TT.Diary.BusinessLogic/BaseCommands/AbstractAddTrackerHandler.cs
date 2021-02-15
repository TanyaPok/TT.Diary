using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractAddTrackerHandler<TCommand, TContainer> : IRequestHandler<TCommand, int>
        where TCommand : AbstractAddTrackerCommand
        where TContainer : TrackedAbstractItem
    {
        private readonly IMapper _mapper;
        private readonly AbstractBaseTrackedContainerRepository<TContainer> _repository;

        protected AbstractAddTrackerHandler(AbstractBaseTrackedContainerRepository<TContainer> repository,
            IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var owner = _repository.GetFirstLevel(request.OwnerId, o => o.Trackers);
            var item = _mapper.Map<Tracker>(request);
            await _repository.AddToAsync(owner, item, cancellationToken);
            return item.Id;
        }
    }
}