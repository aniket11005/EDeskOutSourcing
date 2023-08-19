using System.ComponentModel.DataAnnotations;

namespace EDeskOutSourcing.ViewModels
{
    public class CompanyVM
    {
        [Required(ErrorMessage ="Company Name Required")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Mobile No Required")]
        [RegularExpression(@"^\d{10}", ErrorMessage = "10 digits required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Contact Person Name Required")]
        public string ContactPersonName { get; set; }
    }
}