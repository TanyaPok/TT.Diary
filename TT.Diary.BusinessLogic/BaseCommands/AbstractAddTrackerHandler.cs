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
    public class AbstractAddTrackerHandler<TCommand, TContainer> : IRequestHandler<TCommand, int>
        where TCommand : AbstractAddTrackerCommand
        where TContainer : TrackedAbstractItem
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        protected AbstractAddTrackerHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var owner = _context.Get<TContainer, Tracker>(request.OwnerId, o => o.Trackers);
            var item = _mapper.Map<Tracker>(request);
            owner.Trackers.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return item.Id;
        }
    }
}