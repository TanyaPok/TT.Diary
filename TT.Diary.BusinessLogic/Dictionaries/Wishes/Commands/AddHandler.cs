using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Wishes.Commands
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
            var category = _context.Get<Category, Wish>(request.CategoryId, c => c.Wishes);
            var wish = _mapper.Map<Wish>(request);
            category.AddWish(wish);
            await _context.SaveChangesAsync(cancellationToken);
            return wish.Id;
        }
    }
}