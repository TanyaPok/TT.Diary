using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractSetPriorityHandler<TCommand, TModel> : IRequestHandler<TCommand, bool>
        where TCommand : AbstractSetPriorityCommand
        where TModel : AbstractItem
    {
        private readonly AbstractBaseContainerRepository<TModel> _repository;

        protected AbstractSetPriorityHandler(AbstractBaseContainerRepository<TModel> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var item = _repository.TryGet(e => e.Id == request.Id);
            item.Priority = request.Priority;
            item.PriorityModifyDateTimeUtc = request.DateTime;
            var count = await _repository.SaveAsync(cancellationToken);
            return count > 0;
        }
    }
}