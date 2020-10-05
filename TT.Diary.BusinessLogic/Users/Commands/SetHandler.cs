using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Users.Commands
{
    public class SetHandler : IRequestHandler<SetCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        public SetHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(SetCommand request, CancellationToken cancellationToken)
        {
            var user = _context.TryGet<User>(u => u.Sub == request.Sub);
            if (user == null)
            {
                user = _mapper.Map<User>(request);
                await _context.AddAsync(user, cancellationToken);
                _context.ConfigureUserWorkspaceAsync(user);
            }
            else
            {
                _mapper.Map<SetCommand, User>(request, user);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
