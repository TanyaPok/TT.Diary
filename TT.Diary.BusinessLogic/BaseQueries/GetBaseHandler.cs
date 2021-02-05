using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseQueries
{
    public abstract class GetBaseHandler<TComponent, TModel, TQuery> : IRequestHandler<TQuery, TComponent>
        where TComponent : DTO.Lists.AbstractCategoryItem
        where TModel : AbstractComponent
        where TQuery : AbstractGetBaseQuery<TComponent>
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        protected GetBaseHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<TComponent> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.TryGet<TModel>(e => e.Id == request.Id);
            return Task.FromResult(_mapper.Map<TComponent>(entity));
        }
    }
}