using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Notes.Queries
{
    public class GetItemsHandler : IRequestHandler<GetItemsQuery, Category<DTO.Lists.Note>>
    {
        private readonly IMapper _mapper;
        private readonly NotesContainerRepository _repository;

        public GetItemsHandler(NotesContainerRepository repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<Category<DTO.Lists.Note>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var category = _repository.GetAllLevels(request.UserId, c => c.Notes);
            var result = _mapper.Map<Category, Category<DTO.Lists.Note>>(category);
            return Task.FromResult(result);
        }
    }
}