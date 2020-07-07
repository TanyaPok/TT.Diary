using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.WishList.Commands
{
    public class AddHandler : AbstractAddHandler<AddCommand, Wish, Category>
    {
        public AddHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper, c => c.WishList)
        {
        }
    }
}