using MediatR;
using System.Collections.Generic;

namespace TT.Diary.BusinessLogic.Dictionaries.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<DTO.Category>>
    {
    }
}
