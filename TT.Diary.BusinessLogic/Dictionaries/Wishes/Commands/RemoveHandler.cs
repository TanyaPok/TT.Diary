using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Wishes.Commands
{
    public class RemoveHandler : AsyncRequestHandler<RemoveCommand>
    {
        private readonly DiaryDBContext _context;
        public RemoveHandler(DiaryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override async Task Handle(RemoveCommand request, CancellationToken cancellationToken)
        {
            var book = _context.Find<Wish>(request.Id);
            _context.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}