using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Wishes.Commands
{
    public class EditHandler : AsyncRequestHandler<EditCommand>
    {
        private readonly IMapper _mapper;
        private readonly DiaryDBContext _context;
        public EditHandler(DiaryDBContext context, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        protected override async Task Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var wish = _context.Find<Wish>(request.Id);
            _mapper.Map<EditCommand, Wish>(request, wish);
            var category = _context.Get<Category, Wish>(request.CategoryId, c => c.Wishes);
            category.AddWish(wish);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}