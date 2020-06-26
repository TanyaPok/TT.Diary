using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Queries
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, ViewModel.Category>
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;

        public GetBooksHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<ViewModel.Category> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var category = _context.GetRecursively<Category, Book>(request.Id, c => c.Subcategories, c => c.Books);
            var result = _mapper.Map<Category, ViewModel.Category>(category);
            return Task.FromResult(result);
        }
    }
}