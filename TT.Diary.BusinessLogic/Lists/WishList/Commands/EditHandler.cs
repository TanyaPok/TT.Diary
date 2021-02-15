using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.WishList.Commands
{
    public class EditHandler : AbstractEditHandler<EditCommand, Wish, Category>
    {
        public EditHandler(WishListContainerRepository repository, IMapper mapper) : base(repository, mapper,
            c => c.WishList)
        {
        }
    }
}