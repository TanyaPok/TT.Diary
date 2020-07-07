using MediatR;
using TT.Diary.BusinessLogic.ViewModel;

namespace TT.Diary.BusinessLogic.Dictionaries.BaseQueries
{
    public abstract class AbstractGetBaseQuery<TComponent> : IRequest<TComponent>
        where TComponent : AbstractComponent
    {
        public int Id { get; set; }
    }
}