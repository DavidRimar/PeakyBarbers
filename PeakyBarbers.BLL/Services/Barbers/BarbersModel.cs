using PeakyBarbers.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeakyBarbers.BLL.Services.Barbers
{
    public class BarbersModel
    {

        /* UI FOLDER: Barbers
         * 1. List of Barbers (Barbers and Customers)
         * 2. Create / Edit / Delete (Barbers[Admin] Only)
         * 3. Individual Barber View (Barbers and Customers)
         * 4. Indivudual Barber View - See Working Hours (Barbers and Customers)
         * 5. Individual Barber View - Call to Action > Book Appointment Slot (Customers Only)
         */

        // Barbers

        // barber list view
        public class BarberHeader
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Rating")]
            public int OverallRating { get; set; }

            [Required]
            [Display(Name = "Profile")]
            public string ProfileDescription { get; set; }
        }

        // barber details view
        public class BarberDetails
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Years Of Experience")]
            public int YearsOfExperience { get; set; }

            [Required]
            [Display(Name = "Rating")]
            public int OverallRating { get; set; }

            [Required]
            [Display(Name = "Profile")]
            public string ProfileDescription { get; set; }
        }

        // barber create
        public class BarberCreate
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Years Of Experience")]
            public int YearsOfExperience { get; set; }

            [Required]
            [Display(Name = "Rating")]
            public int OverallRating { get; set; }

            [Required]
            [Display(Name = "Profile")]
            public string ProfileDescription { get; set; }
        }

        // barber edit
        public class BarberEdit
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Years Of Experience")]
            public int YearsOfExperience { get; set; }

            [Required]
            [Display(Name = "Rating")]
            public int OverallRating { get; set; }

            [Required]
            [Display(Name = "Profile")]
            public string ProfileDescription { get; set; }
        }

        // barber delete
        public class BarberDelete
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Years Of Experience")]
            public int YearsOfExperience { get; set; }

            [Required]
            [Display(Name = "Rating")]
            public int OverallRating { get; set; }

            [Required]
            [Display(Name = "Profile")]
            public string ProfileDescription { get; set; }
        }

        // Appointment Slots

        // NO NEED IF WE REDIRECT TO BOOKING SERVICE (with a predefined filter for the BarberID!!!
        public record AppointmentSlotList(int ID, int BarberID, [Display(Name = "Date")] DateTime DayOfYear, TimeSpan StartTime, TimeSpan EndTime) { }

        // Working Hours
        public class WorkingHoursHeader
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Day")]
            public DayOfWeek Day { get; set; }

            [Required]
            [Display(Name = "Start Time")]
            public TimeSpan StartTime { get; set; }

            [Required]
            [Display(Name = "End Time")]
            public TimeSpan EndTime { get; set; }
        }
    }
}