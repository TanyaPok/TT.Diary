using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Notes.Commands
{
    public class EditHandler : IRequestHandler<EditCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        public EditHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var note = _context.TryGet<Note>(e => e.Id == request.Id);
            _mapper.Map<EditCommand, Note>(request, note);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
