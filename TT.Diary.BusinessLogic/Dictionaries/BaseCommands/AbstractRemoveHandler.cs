using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.Framework;

namespace TT.Diary.BusinessLogic.Dictionaries.BaseCommands
{
    public abstract class AbstractRemoveHandler<TCommand, TModel> : AsyncRequestHandler<TCommand>
        where TCommand : AbstractRemoveCommand
        where TModel : AbstractItem
    {
        private readonly DiaryDBContext _context;
        public AbstractRemoveHandler(DiaryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var item = _context.Get<TModel>(request.Id);
            _context.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}