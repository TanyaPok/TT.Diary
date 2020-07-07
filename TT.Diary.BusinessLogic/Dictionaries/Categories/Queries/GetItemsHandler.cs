using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.Framework;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Queries
{
    public class GetItemsHandler : IRequestHandler<GetItemsQuery, ViewModel.Category>
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;

        public GetItemsHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<ViewModel.Category> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var category = _context.GetRecursively<Category, AbstractItem>(request.Id,
                                c => c.Subcategories,
                                new Expression<Func<Category, IEnumerable<AbstractItem>>>[]{
                                    c => c.WishList,
                                    c => c.Habits});
            var result = _mapper.Map<Category, ViewModel.Category>(category);
            return Task.FromResult(result);
        }
    }
}