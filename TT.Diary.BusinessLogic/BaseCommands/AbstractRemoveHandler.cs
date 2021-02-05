using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveHandler<TCommand, TModel> : AsyncRequestHandler<TCommand>
        where TCommand : AbstractRemoveCommand
        where TModel : AbstractEntity
    {
        private readonly DiaryDBContext _context;

        protected AbstractRemoveHandler(DiaryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var item = _context.TryGet<TModel>(e => e.Id == request.Id);
            _context.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}