using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;
using TT.Diary.DataAccessLogic.Model.TimeManagement;

namespace TT.Diary.BusinessLogic.Schedule.Settings.Commands
{
    public class SetHandler : IRequestHandler<SetCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        public SetHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(SetCommand request, CancellationToken cancellationToken)
        {
            var habit = _context.Get<Habit, ScheduleSettings>(request.OwnerScheduleSettingsId, h => h.ScheduleSettings);

            if (habit.ScheduleSettings == null)
            {
                habit.ScheduleSettings = _mapper.Map<ScheduleSettings>(request);
            }
            else
            {
                _mapper.Map(request, habit.ScheduleSettings);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return habit.ScheduleSettings.Id;
        }
    }
}
