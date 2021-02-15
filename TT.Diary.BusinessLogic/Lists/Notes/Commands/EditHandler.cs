using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Notes.Commands
{
    public class EditHandler : IRequestHandler<EditCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly NotesContainerRepository _repository;

        public EditHandler(NotesContainerRepository repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var note = _repository.TryGet(e => e.Id == request.Id);
            _mapper.Map<EditCommand, Note>(request, note);
            return await _repository.SaveAsync(cancellationToken);
        }
    }
}