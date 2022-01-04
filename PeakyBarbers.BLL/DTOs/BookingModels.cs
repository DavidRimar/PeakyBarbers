using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakyBarbers.BLL.Services.DTOs
{
    public class BookingModels
    {
        /* UI FOLDER: Booking
         * (Everyone)
         * 1. List of Appointment Slots for All Barbers
         * 2. Filter By Barbers
         * 3. Navigate by week
         * 
         * (Customer)
         * 1. Book an Appointment Slots (i.e. Edit)
         * 
         * (Barbers)
         * 1. Create / Edit / Delete All Appointment Slots (Barbers[Admin] Only)
         * 2. Create / Edit / Delete My Appointment Slots (Any Barber) - May be in MyProfile (Not a Must)
         */

        // appointment slot view (details) - header (listing)
        public class AppointmentSlotHeader
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Full Name")]
            public string BarberFullName { get; set; }

            [Required]
            [Display(Name = "Day")]
            public DateTime DayOfYear { get; set; }

            [Required]
            [Display(Name = "Start Time")]
            public TimeSpan StartTime { get; set; }

            [Required]
            [Display(Name = "End Time")]
            public TimeSpan EndTime { get; set; }
        }

        // appointment slot create
        public class AppointmentSlotCreate
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Barber")]
            public int BarberId { get; set; }
            /*Just need the BarberId from a selectable dropdown */

            [Required]
            [Display(Name = "Day")]
            public DateTime DayOfYear { get; set; }

            [Required]
            [Display(Name = "Start Time")]
            public TimeSpan StartTime { get; set; }

            [Required]
            [Display(Name = "End Time")]
            public TimeSpan EndTime { get; set; }

            public DateTime CreateDate { get; set; }

            public DateTime ModifiedDate { get; set; }
        }

        // appointment slot edit
        public class AppointmentSlotEdit
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Barber")]
            public int BarberId { get; set; }
            /*Just need the BarberId from a selectable dropdown */

            [Required]
            [Display(Name = "Day")]
            public DateTime DayOfYear { get; set; }

            [Required]
            [Display(Name = "Start Time")]
            public TimeSpan StartTime { get; set; }

            [Required]
            [Display(Name = "End Time")]
            public TimeSpan EndTime { get; set; }

            public DateTime CreateDate { get; set; }

            public DateTime ModifiedDate { get; set; }
        }

        // appointment slot delete
        public class AppointmentSlotDelete
        {
            public int Id { get; set; }
        }
    }
}
