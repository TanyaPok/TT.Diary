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
    public abstract class AbstractEditTrackerHandler<TCommand, TContainer> : IRequestHandler<TCommand, int>
        where TCommand : AbstractEditTrackerCommand
        where TContainer : TrackedAbstractItem
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        protected AbstractEditTrackerHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var tracker = _context.TryGet<Tracker>(t => t.Id == request.Id);
            _mapper.Map(request, tracker);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}