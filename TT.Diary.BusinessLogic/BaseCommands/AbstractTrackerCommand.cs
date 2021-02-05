using MediatR;
using System;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public class AbstractTrackerCommand : IRequest<int>
    {
        public DateTime? DateTime { set; get; }

        public double Progress { set; get; }

        public double? Value { set; get; }
    }
}
