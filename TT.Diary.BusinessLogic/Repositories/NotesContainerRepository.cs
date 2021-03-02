using System;
using System.Collections.Generic;
using System.Linq;
using TT.Diary.BusinessLogic.Repositories.Common;
using TT.Diary.DataAccessLogic;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.Repositories
{
    public class NotesContainerRepository : AbstractBaseContainerRepository<Note>
    {
        private readonly DiaryDBContext _dbContext;

        public NotesContainerRepository(DiaryDBContext dbContext, ICategoryTitleList categoryTitleList) : base(
            dbContext, categoryTitleList.Notes)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IList<DTO.Lists.Note> GetNotes(int userId, DateTime startDate, DateTime finishDate)
        {
            return (from u in _dbContext.Users
                join c in _dbContext.Categories on u.Id equals c.UserId
                join n in _dbContext.Notes on c.Id equals n.CategoryId
                    into result
                from r in result.DefaultIfEmpty()
                where u.Id == userId && (r.ScheduleDateUtc.Date >= startDate && r.ScheduleDateUtc.Date <= finishDate)
                select new DTO.Lists.Note
                {
                    Id = r.Id,
                    Description = r.Description,
                    ScheduleDate = r.ScheduleDateUtc
                }).ToList();
        }
    }
}