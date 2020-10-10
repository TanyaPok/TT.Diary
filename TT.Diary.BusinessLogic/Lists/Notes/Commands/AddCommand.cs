using MediatR;
using System;

namespace TT.Diary.BusinessLogic.Lists.Notes.Commands
{
    public class AddCommand : IRequest<int>
    {
        public int UserId { get; set; }

        public string Description { get; set; }

        public DateTime ScheduleDate { get; set; }
    }
}