using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Queries
{
    public class GetItemsHandler : IRequestHandler<GetItemsQuery, DTO.Category>
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;

        public GetItemsHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<DTO.Category> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var category = _context.GetRecursively<Category, AbstractItem>(request.Id,
                                c => c.Subcategories,
                                new Expression<Func<Category, IEnumerable<AbstractItem>>>[]{
                                    c => c.WishList,
                                    c => c.Habits,
                                    c => c.ToDoList});
            var result = _mapper.Map<Category, DTO.Category>(category);
            return Task.FromResult(result);
        }
    }
}