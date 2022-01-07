using PeakyBarbers.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakyBarbers.BLL.Services.DTOs
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

        public BookingStatus BookingStatus { get; set; }
    }

    // appointment slot create
    // TODO: DayOfYear to show accuracy only to the day
    // TODO: DayOfYear >= Today
    // TODO: StartTime < EndTime
    // TODO: No Overlapping StartTime, EndTime, Day Cominbation
    public class AppointmentSlotCreate
    {

        /// <summary>
        /// Need to specify Barber ID (Admin)
        /// Need to figure out BarberId from Logged In User (Barber)
        /// </summary>
        public int Id { get; set; }

        [Required]
        [Display(Name = "Barber")]
        public int BarberId { get; set; }
        /*Just need the BarberId from a selectable dropdown */

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Day")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DayOfYear { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }

    // appointment slot customer edit
    public class AppointmentSlotCustomerEdit
    {
        /// <summary>
        /// Need to add CustomerId from the logged in User (Customer) - The only thing to Edit is the Booking Status behind the scenes
        /// </summary>
        public int Id { get; set; }

        /* Need to prepopulate from logged in User, readonly on Page, show Customer Name! */
        [Required]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }

        /* Need to be able to select a Service! */
        [Required]
        [Display(Name = "Service Type")]
        public int? ServiceId { get; set; }

        /* Readonly */
        [Required]
        [Display(Name = "Full Name")]
        public string BarberFullName { get; set; }

        [Required]
        [Display(Name = "Day")]
        public DateTime DayOfYear { get; set; }

        // TODO: StartTime < EndTime
        [Required]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }

        /* Modified Date and Booking Status set at the Business layer no need to pull them! */
    }

    // appointment slot customer edit
    public class AppointmentSlotBarberEdit
    {
        /// <summary>
        /// Need to consider scenarios for Barbers:
        ///     1. Edit my details when logged in (Barber)
        ///     2. Edit any barbers app slot (Admin) - No Clash Check!
        /// </summary>
        public int Id { get; set; }

        /* Need to prepopulate from logged in User, readonly on Page, show Barber Name! */
        [Required]
        [Display(Name = "Barber")]
        public int? BarberId { get; set; }

        /* Readonly */
        [Required]
        [Display(Name = "Full Name")]
        public string BarberFullName { get; set; }

        /* Barber to be able to edit the below fields only! */
        [Required]
        [Display(Name = "Day")]
        public DateTime DayOfYear { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }

        [Required]
        [Display(Name = "Status")]
        public BookingStatus BookingStatus { get; set; }


    }

    // appointment slot delete
    public class AppointmentSlotDelete
    {
        public int Id { get; set; }
    }
}

