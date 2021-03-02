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
    public abstract class AbstractEditHandler<TCommand, TModel> : IRequestHandler<TCommand, int>
        where TCommand : AbstractEditCommand
        where TModel : AbstractItem
    {
        private readonly IMapper _mapper;
        private readonly AbstractBaseContainerRepository<TModel> _repository;
        private readonly Expression<Func<Category, IEnumerable<TModel>>> _expression;

        protected AbstractEditHandler(AbstractBaseContainerRepository<TModel> repository, IMapper mapper,
            Expression<Func<Category, IEnumerable<TModel>>> expression)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var item = _repository.TryGet(e => e.Id == request.Id);
            _mapper.Map<TCommand, TModel>(request, item);
            var category = _repository.GetFirstLevel(request.CategoryId, _expression);
            return await _repository.AddToAsync(category, item, cancellationToken);
        }
    }
}