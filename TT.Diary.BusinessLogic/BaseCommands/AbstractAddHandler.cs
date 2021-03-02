using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractAddHandler<TCommand, TModel> : IRequestHandler<TCommand, int>
        where TCommand : AbstractCommand
        where TModel : AbstractItem
    {
        private readonly IMapper _mapper;
        private readonly AbstractBaseContainerRepository<TModel> _repository;
        private readonly Expression<Func<Category, IEnumerable<TModel>>> _expression;

        protected AbstractAddHandler(AbstractBaseContainerRepository<TModel> repository, IMapper mapper,
            Expression<Func<Category, IEnumerable<TModel>>> expression)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var category = _repository.GetFirstLevel(request.CategoryId, _expression);
            var item = _mapper.Map<TModel>(request);
            await _repository.AddToAsync(category, item, cancellationToken);
            return item.Id;
        }
    }
}