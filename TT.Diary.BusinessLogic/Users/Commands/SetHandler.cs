using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Users.Commands
{
    public class SetHandler : IRequestHandler<SetCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly UserRepository _repository;

        public SetHandler(IMapper mapper, UserRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> Handle(SetCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.TryGet(u => u.Sub == request.Sub);
            if (user != null) return user.Id;
            user = _mapper.Map<User>(request);
            await _repository.AddAsync(user, cancellationToken);
            return user.Id;
        }
    }
}