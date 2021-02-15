using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveHandler<TCommand, TModel, TContainer> : AsyncRequestHandler<TCommand>
        where TCommand : AbstractRemoveCommand
        where TModel : AbstractEntity
        where TContainer : Category
    {
        private readonly AbstractBaseContainerRepository<TContainer, TModel> _repository;

        protected AbstractRemoveHandler(AbstractBaseContainerRepository<TContainer, TModel> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var item = _repository.TryGet(e => e.Id == request.Id);
            await _repository.RemoveAsync(item, cancellationToken);
        }
    }
}