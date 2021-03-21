using AutoMapper;
using TT.Diary.BusinessLogic.BaseQueries;
using TT.Diary.BusinessLogic.DTO.TimeManagement;
using TT.Diary.BusinessLogic.Repositories;

namespace TT.Diary.BusinessLogic.Lists.Appointments.Queries
{
    public class GetHandler : AbstractGetBaseHandler<DTO.Lists.Appointment<ScheduleSettingsSummary>,
        DataAccessLogic.Model.TypeList.Appointment, GetQuery>
    {
        public GetHandler(AppointmentsContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}