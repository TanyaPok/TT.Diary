using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractSetScheduledHandler<TCommand, TOwner> : IRequestHandler<TCommand, int>
        where TCommand : AbstractScheduledCommand
        where TOwner : AbstractItem
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        protected AbstractSetScheduledHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var owner = _context.Get<TOwner, ScheduleSettings>(request.OwnerId, e => e.Schedule);

            if (owner.Schedule != null)
            {
                _mapper.Map<TCommand, ScheduleSettings>(request, owner.Schedule);
            }
            else
            {
                var schedule = _mapper.Map<ScheduleSettings>(request);
                owner.Schedule = schedule;
            }

            await _context.SaveChangesAsync(cancellationToken);
            return owner.Schedule.Id;
        }
    }
}