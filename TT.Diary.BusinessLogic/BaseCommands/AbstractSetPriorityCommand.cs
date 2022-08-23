using System;
using MediatR;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.BaseCommands
{
    public abstract class AbstractSetPriorityCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public Priority Priority { get; set; }
        public DateTime DateTime { get; set; }
    }
}