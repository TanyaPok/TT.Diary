using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Schedule.Settings.Queries
{
    public class GetHandler : IRequestHandler<GetQuery, ViewModel.ScheduleSettings>
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;
        public GetHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<ViewModel.ScheduleSettings> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var entity = _context.Get<ScheduleSettings>(request.Id);
            return Task.FromResult(_mapper.Map<ViewModel.ScheduleSettings>(entity));
        }
    }
}