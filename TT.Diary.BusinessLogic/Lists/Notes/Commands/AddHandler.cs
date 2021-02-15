using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Notes.Commands
{
    public class AddHandler : IRequestHandler<AddCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly NotesContainerRepository _repository;

        public AddHandler(NotesContainerRepository repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var category = _repository.GetAllLevels(request.UserId, c => c.Notes);
            var item = _mapper.Map<Note>(request);
            await _repository.AddToAsync(category, item, cancellationToken);
            return item.Id;
        }
    }
}