using System.Collections.Generic;
using MediatR;
using TT.Diary.BusinessLogic.DTO.TimeManagement;

namespace TT.Diary.BusinessLogic.TimeManagement.Queries
{
    public class GetNonPrioritizedActivityQuery : IRequest<List<NonPrioritizedActivity>>
    {
        public int UserId { get; set; }
    }
}