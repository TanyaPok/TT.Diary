using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model;

namespace TT.Diary.BusinessLogic.Dictionaries.Books.Commands
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
            var book = _context.Find<Book>(request.Id);
            _mapper.Map<EditCommand, Book>(request, book);
            var category = _context.Get<Category, Book>(request.CategoryId, c => c.Books);
            category.AddBook(book);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}