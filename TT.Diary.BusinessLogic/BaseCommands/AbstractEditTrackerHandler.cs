using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractEditTrackerHandler<TCommand, TContainer> : IRequestHandler<TCommand, int>
        where TCommand : AbstractEditTrackerCommand
        where TContainer : TrackedAbstractItem
    {
        private readonly IMapper _mapper;
        private readonly AbstractBaseTrackedContainerRepository<TContainer> _repository;

        protected AbstractEditTrackerHandler(AbstractBaseTrackedContainerRepository<TContainer> repository,
            IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var tracker = _repository.TryGet(t => t.Id == request.Id);
            _mapper.Map(request, tracker);
            return await _repository.SaveAsync(cancellationToken);
        }
    }
}