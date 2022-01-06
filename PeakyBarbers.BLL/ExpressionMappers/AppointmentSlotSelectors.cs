using PeakyBarbers.Data.Entities;
using System;
using System.Linq.Expressions;
using PeakyBarbers.BLL.Services.DTOs;

namespace PeakyBarbers.BLL.ExpressionMappers
{
    public static class AppointmentSlotSelectors
    {

        /// <summary>
        /// AppointmentSlotHeader Selector
        /// </summary>
        public static Expression<Func<AppointmentSlot, AppointmentSlotHeader>> AppointmentSlotHeaderSelector = a => new AppointmentSlotHeader
        {
            Id = a.Id,
            BarberFullName = a.Barber.FirstName + " " + a.Barber.LastName,
            DayOfYear = a.DayOfYear,
            StartTime = a.StartTime,
            EndTime = a.EndTime,
            BookingStatus = a.BookingStatus
        };

        /// <summary>
        /// AppointmentSlotCustomerEdit Selector
        /// </summary>
        public static Expression<Func<AppointmentSlot, AppointmentSlotCustomerEdit>> AppointmentSlotCustomerEditSelector = a => new AppointmentSlotCustomerEdit
        {
            Id = a.Id,
            CustomerId = a.CustomerId, // this is meant to be Null at the time of booking
            ServiceId = a.ServiceId, // this is meant to be Null at the time of booking
            BarberFullName = a.Barber.FirstName + " " + a.Barber.LastName,
            DayOfYear = a.DayOfYear,
            StartTime = a.StartTime,
            EndTime = a.EndTime
        };

    }
}
