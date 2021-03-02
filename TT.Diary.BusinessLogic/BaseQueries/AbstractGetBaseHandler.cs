using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseQueries
{
    public abstract class AbstractGetBaseHandler<TComponent, TModel, TQuery> : IRequestHandler<TQuery, TComponent>
        where TComponent : DTO.Lists.AbstractCategoryItem
        where TModel : AbstractComponent
        where TQuery : AbstractGetBaseQuery<TComponent>
    {
        private readonly IMapper _mapper;
        private readonly AbstractBaseRepository<TModel> _repository;

        protected AbstractGetBaseHandler(AbstractBaseRepository<TModel> repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<TComponent> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.TryGet(e => e.Id == request.Id);
            return Task.FromResult(_mapper.Map<TComponent>(entity));
        }
    }
}