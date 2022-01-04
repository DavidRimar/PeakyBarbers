using PeakyBarbers.BLL.Services.DTOs;
using PeakyBarbers.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeakyBarbers.BLL.ExpressionMappers
{
    public static class WorkingHourExpressions {

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
