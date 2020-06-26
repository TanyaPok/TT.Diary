using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Commands
{
    public class EditHandler : AsyncRequestHandler<EditCommand>
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;
        public EditHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override async Task Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.FindAsync<Category>(request.Id);

            _mapper.Map<EditCommand, TT.Diary.DataAccessLogic.Model.Category>(request, category);

            if (request.OldCategoryId != 0)
            {
                var oldParent = _context.Get<Category, Category>(request.OldCategoryId, c => c.Subcategories);
                oldParent.RemoveCategory(category);
            }

            if (request.CategoryId != 0)
            {
                var parent = _context.Get<Category, Category>(request.CategoryId, c => c.Subcategories);
                parent.AddCategory(category);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}