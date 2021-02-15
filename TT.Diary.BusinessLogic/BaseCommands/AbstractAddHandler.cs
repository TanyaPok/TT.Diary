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
    public abstract class AbstractAddHandler<TCommand, TModel, TContainer> : IRequestHandler<TCommand, int>
        where TCommand : AbstractCommand
        where TModel : AbstractItem
        where TContainer : Category
    {
        private readonly IMapper _mapper;
        private readonly AbstractBaseContainerRepository<TContainer, TModel> _repository;
        private readonly Expression<Func<TContainer, IEnumerable<TModel>>> _expression;

        protected AbstractAddHandler(AbstractBaseContainerRepository<TContainer, TModel> repository, IMapper mapper,
            Expression<Func<TContainer, IEnumerable<TModel>>> expression)
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