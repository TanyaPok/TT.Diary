using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Notes.Commands
{
    public class AddHandler : IRequestHandler<AddCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly DiaryDBContext _context;

        public AddHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var category = _context.GetNotes(request.UserId);
            var item = _mapper.Map<Note>(request);
            category.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return item.Id;
        }
    }
}