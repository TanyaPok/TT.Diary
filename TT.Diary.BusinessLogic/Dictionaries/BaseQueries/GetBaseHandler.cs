using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.BusinessLogic.ViewModel;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.BaseQueries
{
    public class GetBaseHandler<TComponent, TModel, TQuery> : IRequestHandler<TQuery, TComponent>
        where TComponent : IComponent
        where TModel : AbstractEntity
        where TQuery : AbstractGetBaseQuery<TComponent>
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;
        public GetBaseHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<TComponent> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.GetAsync<TModel>(request.Id, cancellationToken);
            return _mapper.Map<TComponent>(entity);
        }
    }
}