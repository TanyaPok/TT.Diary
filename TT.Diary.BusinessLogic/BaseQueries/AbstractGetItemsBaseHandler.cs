using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic.Model;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.BaseQueries
{
    public abstract class AbstractGetItemsBaseHandler<TQuery, TModel, TDto> : IRequestHandler<TQuery, Category<TDto>>
        where TQuery : AbstractGetItemsBaseQuery<TDto>
        where TModel : AbstractItem
        where TDto : AbstractScheduledItem<ScheduleSettingsSummary>
    {
        private readonly IMapper _mapper;
        private readonly AbstractBaseScheduledItemRepository<TModel> _repository;
        private readonly Expression<Func<Category, IEnumerable<TModel>>> _expression;

        public AbstractGetItemsBaseHandler(AbstractBaseScheduledItemRepository<TModel> repository, IMapper mapper,
            Expression<Func<Category, IEnumerable<TModel>>> expression)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _expression = expression ?? throw new ArgumentNullException(nameof(expression));

        }

        public Task<Category<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var category = (request.OnlyUnscheduled)
                ? _repository.GetAllUnscheduledLevels(request.UserId)
                : _repository.GetAllLevels(request.UserId, _expression);

            var result = _mapper.Map<Category, Category<TDto>>(category);
            return Task.FromResult(result);
        }
    }
}