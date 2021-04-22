using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Lists.Categories.Commands
{
    public class AddHandler : IRequestHandler<AddCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly CategoriesContainerRepository _repository;

        public AddHandler(CategoriesContainerRepository repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var newCategory = _mapper.Map<Category>(request);

            if (request.CategoryId == 0)
            {
                await _repository.AddAsync(newCategory, cancellationToken);
            }
            else
            {
                var parent = _repository.GetFirstLevel(
                    request.CategoryId,
                    c => c.Subcategories);
                _repository.AddTo(parent, newCategory);
            }

            await _repository.SaveAsync(cancellationToken);
            return newCategory.Id;
        }
    }
}