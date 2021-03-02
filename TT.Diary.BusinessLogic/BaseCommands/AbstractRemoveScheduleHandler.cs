using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveScheduleHandler<TCommand, TModel> : AsyncRequestHandler<TCommand>
        where TCommand : AbstractRemoveCommand
        where TModel : AbstractItem
    {
        private readonly AbstractBaseContainerRepository<TModel> _repository;
        private readonly AbstractBaseRepository<ScheduleSettings> _scheduleRepository;

        protected AbstractRemoveScheduleHandler(AbstractBaseContainerRepository<TModel> repository, AbstractBaseRepository<ScheduleSettings> scheduleRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _scheduleRepository = scheduleRepository ?? throw new ArgumentNullException(nameof(scheduleRepository));
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var owner = _repository.Get(s => s.ScheduleId == request.Id, s => s.Schedule);
            await _scheduleRepository.RemoveAsync(owner.Schedule, cancellationToken);
        }
    }
}