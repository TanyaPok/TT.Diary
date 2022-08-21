using System;
using System.Collections.Generic;
using MediatR;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetPrioritizedActivityQuery : IRequest<List<PrioritizedActivity>>
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}