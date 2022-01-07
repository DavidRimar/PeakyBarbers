using System.ComponentModel.DataAnnotations;

namespace PeakyBarbers.BLL.Services.DTOs
{
    
    /* UI FOLDER: Services
        * 1. List of Services (Barbers and Customers)
        * 2. Create / Edit / Delete (Barbers[Admin] Only)
        */

    // service view
    public class ServiceHeader
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
        public int ApproximateServiceDurationInMinutes { get; set; }
    }

    // service create
    public class ServiceCreate
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ServiceName { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Service Fee")]
        public decimal ServiceFee { get; set; }

        [Required]
        [Display(Name = "Service Discription")]
        public string ServiceDescription { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Duration")]
        public int ApproximateServiceDurationInMinutes { get; set; }
    }

    // service edit
    public class ServiceEdit
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ServiceName { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Service Fee")]
        public decimal ServiceFee { get; set; }

        [Required]
        [Display(Name = "Service Discription")]
        public string ServiceDescription { get; set; }

        [Required]
        [Range(1, 1000)]
        [Display(Name = "Duration")]
        public int ApproximateServiceDurationInMinutes { get; set; }
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
        [Display(Name = "Service Discription")]
        public string ServiceDescription { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public int ApproximateServiceDurationInMinutes { get; set; }
    }
}

