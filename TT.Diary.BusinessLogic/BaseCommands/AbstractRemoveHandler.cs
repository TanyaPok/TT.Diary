using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractRemoveHandler<TCommand, TModel> : AsyncRequestHandler<TCommand>
        where TCommand : AbstractRemoveCommand
        where TModel : AbstractEntity
    {
        private readonly AbstractBaseContainerRepository<TModel> _repository;

        protected AbstractRemoveHandler(AbstractBaseContainerRepository<TModel> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        protected override async Task Handle(TCommand request, CancellationToken cancellationToken)
        {
            var item = _repository.TryGet(e => e.Id == request.Id);
            _repository.Remove(item);
            await _repository.SaveAsync(cancellationToken);
        }
    }
}