using System.ComponentModel.DataAnnotations;

namespace EDeskOutSourcing.ViewModels
{
    public class SignInVM
    {
        [Required(ErrorMessage ="EmailID Required")]
        [EmailAddress(ErrorMessage ="Invalid EmailID")]
        public string EmailID { get; set; }
        [Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
