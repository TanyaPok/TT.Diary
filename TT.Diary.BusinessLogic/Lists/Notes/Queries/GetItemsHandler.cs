using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.BusinessLogic.DTO.Lists;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Notes.Queries
{
    public class GetItemsHandler : IRequestHandler<GetItemsQuery, Category<DTO.Lists.Note>>
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        public GetItemsHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Category<DTO.Lists.Note>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var category = _context.GetNotes(request.UserId);
            var result = _mapper.Map<Category, Category<DTO.Lists.Note>>(category);
            return Task.FromResult(result);
        }
    }
}