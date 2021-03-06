﻿using AutoMapper;
using TT.Diary.BusinessLogic.BaseCommands;
using TT.Diary.BusinessLogic.Repositories;
using TT.Diary.DataAccessLogic.Model.TypeList;

namespace TT.Diary.BusinessLogic.TimeManagement.HabitTracker.Commands
{
    public class EditHandler : AbstractEditTrackerHandler<EditCommand, Habit>
    {
        public EditHandler(TrackedHabitsContainerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}