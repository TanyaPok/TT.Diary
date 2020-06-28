using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Queries
{
    public class GetWishListHandler : IRequestHandler<GetWishListQuery, ViewModel.Category>
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;

        public GetWishListHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<ViewModel.Category> Handle(GetWishListQuery request, CancellationToken cancellationToken)
        {
            var category = _context.GetRecursively<Category, Wish>(request.Id, c => c.Subcategories, c => c.Wishes);
            var result = _mapper.Map<Category, ViewModel.Category>(category);
            return Task.FromResult(result);
        }
    }
}