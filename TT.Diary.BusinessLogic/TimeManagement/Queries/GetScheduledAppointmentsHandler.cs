using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetScheduledAppointmentsHandler : IRequestHandler<GetScheduledAppointmentsQuery,
        List<DailyScheduledAppointments>>
    {
        private readonly TrackedAppointmentsContainerRepository _repository;

        public GetScheduledAppointmentsHandler(TrackedAppointmentsContainerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<List<DailyScheduledAppointments>> Handle(GetScheduledAppointmentsQuery request,
            CancellationToken cancellationToken)
        {
            var dailyAppointments = new List<DailyScheduledAppointments>();

            // initial data selection
            var appointments =
                _repository.GetTrackedList(request.UserId, request.StartDate.Date, request.FinishDate.Date);

            // filter by repeated options
            for (var i = appointments.Count - 1; i >= 0; i--)
            {
                appointments[i].Schedule.SetTrackerStrategy();

                if (!appointments[i].Schedule.TryGenerateTrackers(request.StartDate.Date, request.FinishDate.Date))
                {
                    appointments.Remove(appointments[i]);
                }
            }

            foreach (var appointment in appointments)
            {
                foreach (var tracker in appointment.Schedule.Trackers)
                {
                    var item = dailyAppointments.FirstOrDefault(a => a.Date == tracker.ScheduledDate.Date);

                    if (item == null)
                    {
                        item = new DailyScheduledAppointments()
                        {
                            Date = tracker.ScheduledDate.Date,
                            DoneAppointments = new List<Tuple<DateTime, string>>(),
                            ScheduledAppointments = new List<Tuple<DateTime, string>>()
                        };
                        dailyAppointments.Add(item);
                    }

                    if (tracker.Progress == 0)
                    {
                        item.ScheduledAppointments.Add(new Tuple<DateTime, string>(
                            tracker.ScheduledDate.Date.AddHours(appointment.Schedule.ScheduledStartDateTime.Hour)
                                .AddMinutes(appointment.Schedule.ScheduledStartDateTime.Minute),
                            appointment.Description));
                    }
                    else
                    {
                        item.DoneAppointments.Add(new Tuple<DateTime, string>(
                            tracker.ScheduledDate.Date.AddHours(appointment.Schedule.ScheduledStartDateTime.Hour)
                                .AddMinutes(appointment.Schedule.ScheduledStartDateTime.Minute),
                            appointment.Description));
                    }
                }
            }

            dailyAppointments.ForEach(da =>
            {
                da.ScheduledAppointments.Sort();
                da.DoneAppointments.Sort();
            });

            return Task.FromResult(dailyAppointments.OrderBy(a => a.Date).ToList());
        }
    }
}