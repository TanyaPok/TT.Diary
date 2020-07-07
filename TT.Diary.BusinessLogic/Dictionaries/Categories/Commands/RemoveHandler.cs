using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Commands
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
            var category = _context.GetRecursively<Category>(
                    request.Id,
                    c => c.Subcategories);
            RemoveSubcategories(category);
            _context.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private void RemoveSubcategories(Category category)
        {
            for(var i = category.Subcategories.Count - 1; i >= 0; i--)
            {
                RemoveSubcategories(category.Subcategories[i]);
                var child = category.Subcategories[i];
                category.Remove(child);
                _context.Remove(child);
            }
        }
    }
}