using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Commands
{
    public class AddHandler : IRequestHandler<AddCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;

        public AddHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var newCategory = _mapper.Map<Category>(request);

            if (request.CategoryId == 0)
            {
                await _context.AddAsync(newCategory, cancellationToken);
            }
            else
            {
                var parent = _context.Get<Category, Category>(
                    request.CategoryId,
                    c => c.Subcategories);
                parent.Add(newCategory);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return newCategory.Id;
        }
    }
}