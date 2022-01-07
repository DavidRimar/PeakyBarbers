using PeakyBarbers.BLL.Services.DTOs;
using PeakyBarbers.Data.Entities;
using System;
using System.Linq.Expressions;

namespace PeakyBarbers.BLL.ExpressionMappers
{
    public static class BarberSelectors {

        /// <summary>
        /// BarberHeader Selector
        /// </summary>
        public static Expression<Func<Barber, BarberHeader>> BarberHeaderSelector = b => new BarberHeader
        {
            Id = b.Id,
            FirstName = b.FirstName,
            LastName = b.LastName,
            OverallRating = b.OverallRating,
            ProfileDescription = b.ProfileDescription
        };

        /// <summary>
        /// BarberDetails Selector
        /// </summary>
        public static Expression<Func<Barber, BarberDetails>> BarberDetailsSelector = b => new BarberDetails
        {
            Id = b.Id,
            FirstName = b.FirstName,
            LastName = b.LastName,
            Gender = b.Gender,
            Email = b.Email,
            YearsOfExperience = (int)b.YearsOfExperience,
            OverallRating = (int)b.OverallRating,
            ProfileDescription = b.ProfileDescription

        };

        /// <summary>
        /// BarberEdit Selector
        /// </summary>
        public static Expression<Func<Barber, BarberEdit>> BarberEditSelector = b => new BarberEdit
        {
            Id = b.Id,
            FirstName = b.FirstName,
            LastName = b.LastName,
            Gender = b.Gender,
            Email = b.Email,
            YearsOfExperience = (int)b.YearsOfExperience,
            OverallRating = (int)b.OverallRating,
            ProfileDescription = b.ProfileDescription

        };

        public static Expression<Func<AppointmentSlot, AppointmentSlotList>> AppointmentSlotListSelector = a => new AppointmentSlotList
        {
            Id = a.Id,
            barberId = a.BarberId,
            barberFullName = a.Barber.FirstName + " " + a.Barber.LastName,
            Day = a.DayOfYear,
            StartTime = a.StartTime,
            EndTime = a.EndTime
            
        };

        public static Expression<Func<Barber, BarberFullName>> BarberFullNameSelector = b => new BarberFullName
        {
            barberFullName = b.FirstName + " " + b.LastName
        };
    }
}
