using MediatR;

namespace TT.Diary.BusinessLogic.Users.Commands
{
    public class SetCommand : IRequest<int>
    {
        public string Given_Name { get; set; }

        public string Sub { get; set; }
    }
}