using MediatR;
using TT.Diary.BusinessLogic.ViewModel;

namespace TT.Diary.BusinessLogic.Dictionaries.Queries
{
    public abstract class AbstractGetBaseQuery<TComponent> : IRequest<TComponent>
        where TComponent : IComponent
    {
        public int Id { get; set; }
    }
}