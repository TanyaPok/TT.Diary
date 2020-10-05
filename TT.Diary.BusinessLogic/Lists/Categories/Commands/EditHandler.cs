using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Categories.Commands
{
    public class EditHandler : IRequestHandler<EditCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        public EditHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var category = _context.TryGet<Category>(e => e.Id == request.Id);

            _mapper.Map<EditCommand, Category>(request, category);

            if (request.OldCategoryId != 0)
            {
                var oldParent = _context.Get<Category, Category>(
                    request.OldCategoryId,
                    c => c.Subcategories);
                oldParent.Remove(category);
            }

            if (request.CategoryId != 0)
            {
                var parent = _context.Get<Category, Category>(
                    request.CategoryId,
                    c => c.Subcategories);
                parent.Add(category);
            }

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}