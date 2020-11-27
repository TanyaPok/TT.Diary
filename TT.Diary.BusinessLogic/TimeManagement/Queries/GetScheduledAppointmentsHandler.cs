using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.DataAccessLogic;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetScheduledAppointmentsHandler : IRequestHandler<GetScheduledAppointmentsQuery, List<DailyScheduledAppointments>>
    {
        private readonly string FORMAT_DESCRIPTION = "{0:hh:mm} {1}";
        private readonly DiaryDBContext _context;
        private readonly DataReceiver _dataReceiver;

        public GetScheduledAppointmentsHandler(DiaryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dataReceiver = new DataReceiver();
        }

        public Task<List<DailyScheduledAppointments>> Handle(GetScheduledAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var dailyAppointments = new List<DailyScheduledAppointments>();

            // initial data selection
            var appointments = _dataReceiver.GetAppointments(_context, request.UserId, request.StartDate.Date, request.FinishDate.Date);

            // filter by repeated options
            for (int i = appointments.Count - 1; i >= 0; i--)
            {
                appointments[i].SetTrackerStrategy();

                if (!appointments[i].TryGenerateTrackers(request.StartDate.Date, request.FinishDate.Date))
                {
                    appointments.Remove(appointments[i]);
                }
            }

            foreach (var appointment in appointments)
            {
                foreach (var tracker in appointment.Trackers)
                {
                    var item = dailyAppointments.FirstOrDefault(a => a.Date == tracker.ScheduledDate.Date);

                    if (item == null)
                    {
                        item = new DailyScheduledAppointments()
                        {
                            Date = tracker.ScheduledDate.Date,
                            DoneAppointmentsDescriptions = new List<string>(),
                            ScheduledAppointmentsDescriptions = new List<string>()
                        };
                        dailyAppointments.Add(item);
                    }

                    if (tracker.Progress == 0)
                    {
                        item.ScheduledAppointmentsDescriptions.Add(string.Format(FORMAT_DESCRIPTION, tracker.ScheduledDate, appointment.Description));
                    }
                    else
                    {
                        item.DoneAppointmentsDescriptions.Add(string.Format(FORMAT_DESCRIPTION, tracker.ScheduledDate, appointment.Description));
                    }
                }
            }

            return Task.FromResult(dailyAppointments.OrderBy(a => a.Date).ToList());
        }
    }
}
