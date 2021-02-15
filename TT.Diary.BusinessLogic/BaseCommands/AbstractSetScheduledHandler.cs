using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TimeManagement;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractSetScheduledHandler<TCommand, TOwner, TContainer> : IRequestHandler<TCommand, int>
        where TCommand : AbstractScheduledCommand
        where TOwner : AbstractItem
        where TContainer : Category
    {
        private readonly IMapper _mapper;
        private readonly AbstractBaseContainerRepository<TContainer, TOwner> _repository;

        protected AbstractSetScheduledHandler(AbstractBaseContainerRepository<TContainer, TOwner> repository,
            IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var owner = _repository.Get<ScheduleSettings>(request.OwnerId, e => e.Schedule);

            if (owner.Schedule != null)
            {
                _mapper.Map<TCommand, ScheduleSettings>(request, owner.Schedule);
            }
            else
            {
                var schedule = _mapper.Map<ScheduleSettings>(request);
                owner.Schedule = schedule;
            }

            await _repository.SaveAsync(cancellationToken);
            return owner.Schedule.Id;
        }
    }
}