using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Categories.Commands
{
    public class EditHandler : IRequestHandler<EditCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly CategoriesContainerRepository _repository;

        public EditHandler(CategoriesContainerRepository repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var category = _repository.TryGet(e => e.Id == request.Id);

            _mapper.Map<EditCommand, Category>(request, category);

            if (request.OldCategoryId != 0)
            {
                var oldParent = _repository.GetFirstLevel(
                    request.OldCategoryId,
                    c => c.Subcategories);
                _repository.RemoveFrom(oldParent, category);
            }

            if (request.CategoryId != 0)
            {
                var parent = _repository.GetFirstLevel(
                    request.CategoryId,
                    c => c.Subcategories);
                _repository.AddTo(parent, category);
            }

            return await _repository.SaveAsync(cancellationToken);
        }
    }
}