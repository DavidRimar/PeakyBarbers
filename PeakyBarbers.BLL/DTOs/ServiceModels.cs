using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakyBarbers.BLL.Services.DTOs
{
    public class ServiceModels
    {
        /* UI FOLDER: Services
         * 1. List of Services (Barbers and Customers)
         * 2. Create / Edit / Delete (Barbers[Admin] Only)
         */

        // service view
        public class ServiceView
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Name")]
            public string ServiceName { get; set; }

            [Required]
            [Display(Name = "Service Fee")]
            public decimal ServiceFee { get; set; }

            [Required]
            [Display(Name = "Duration")]
            public int ApproximateServiceDurationInMinute { get; set; }
        }

        // service create
        public class ServiceCreate
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Name")]
            public string ServiceName { get; set; }

            [Required]
            [Display(Name = "Service Fee")]
            public decimal ServiceFee { get; set; }

            [Required]
            [Display(Name = "Duration")]
            public int ApproximateServiceDurationInMinute { get; set; }
        }

        // service edit
        public class ServiceEdit
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Name")]
            public string ServiceName { get; set; }

            [Required]
            [Display(Name = "Service Fee")]
            public decimal ServiceFee { get; set; }

            [Required]
            [Display(Name = "Duration")]
            public int ApproximateServiceDurationInMinute { get; set; }
        }

        // service delete
        public class ServiceDelete
        {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Name")]
            public string ServiceName { get; set; }

            [Required]
            [Display(Name = "Service Fee")]
            public decimal ServiceFee { get; set; }

            [Required]
            [Display(Name = "Duration")]
            public int ApproximateServiceDurationInMinute { get; set; }
        }
    }
}
