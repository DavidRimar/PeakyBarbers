using PeakyBarbers.BLL.Services.DTOs;
using PeakyBarbers.Data.Entities;
using System;
using System.Linq.Expressions;

namespace PeakyBarbers.BLL.ExpressionMappers
{
    public static class WorkingHourSelectors {

        /// <summary>
        /// BarberHeader Selector
        /// </summary>
        public static Expression<Func<WorkingHour, WorkingHoursHeader>> WorkingHoursSelector = w => new WorkingHoursHeader
        {
            Id = w.Id,
            BarberId = w.BarberId,
            Day = w.Day,
            StartTime = w.StartTime,
            EndTime = w.EndTime
        };

    }
}
