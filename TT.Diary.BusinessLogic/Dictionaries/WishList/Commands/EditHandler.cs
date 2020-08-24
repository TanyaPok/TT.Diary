using AutoMapper;
using TT.Diary.BusinessLogic.Dictionaries.BaseCommands;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Dictionaries.WishList.Commands
{
    public class EditHandler : AbstractEditHandler<EditCommand, Wish, Category>
    {
        public EditHandler(DiaryDBContext context, IMapper mapper) : base(context, mapper, c => c.WishList)
        {
        }
    }
}