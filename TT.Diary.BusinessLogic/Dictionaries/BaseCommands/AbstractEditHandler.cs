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

namespace TT.Diary.BusinessLogic.Dictionaries.BaseCommands
{
    public abstract class AbstractEditHandler<TCommand, TModel, TContainer> : IRequestHandler<TCommand, int>
        where TCommand : AbstractEditCommand
        where TModel : AbstractItem
        where TContainer : Category
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;
        private readonly Expression<Func<TContainer, IEnumerable<TModel>>> _expression;

        public AbstractEditHandler(DiaryDBContext context, IMapper mapper, Expression<Func<TContainer, IEnumerable<TModel>>> expression)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var item = _context.Get<TModel>(request.Id);
            _mapper.Map<TCommand, TModel>(request, item);
            var category = _context.Get<TContainer, TModel>(request.CategoryId, _expression);
            category.Add(item);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}