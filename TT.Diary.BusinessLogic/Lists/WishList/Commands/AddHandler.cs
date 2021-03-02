using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.WishList.Commands
{
    public class AddHandler : AbstractAddHandler<AddCommand, Wish>
    {
        public AddHandler(WishListContainerRepository repository, IMapper mapper) : base(repository, mapper,
            c => c.WishList)
        {
        }
    }
}