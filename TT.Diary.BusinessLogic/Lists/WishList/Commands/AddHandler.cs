using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.WishList.Commands
{
    public class AddHandler : AbstractAddHandler<AddCommand, Wish, Category>
    {
        public AddHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper, c => c.WishList)
        {
        }
    }
}