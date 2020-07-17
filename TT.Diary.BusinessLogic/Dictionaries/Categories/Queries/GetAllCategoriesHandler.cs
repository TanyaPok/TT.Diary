using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.Framework;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Queries
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<ViewModel.Category>>
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;

        public GetAllCategoriesHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<ViewModel.Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = _context.GetRecursively<Category, AbstractItem>(c => c.Subcategories,
                               new Expression<Func<Category, IEnumerable<AbstractItem>>>[]{
                                    c => c.WishList,
                                    c => c.Habits,
                                    c => c.ToDoList});
            var result = _mapper.Map<List<Category>, List<ViewModel.Category>>(categories);
            return Task.FromResult(result);
        }
    }
}
