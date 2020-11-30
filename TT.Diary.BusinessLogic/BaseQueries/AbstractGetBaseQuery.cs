using MediatR;
using TT.Diary.BusinessLogic.DTO.Lists;

namespace TT.Diary.BusinessLogic.BaseQueries
{
    public abstract class AbstractGetBaseQuery<TComponent> : IRequest<TComponent>
        where TComponent : IItem
    {
        public int Id { get; set; }
    }
}