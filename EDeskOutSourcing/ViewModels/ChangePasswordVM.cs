using System.ComponentModel.DataAnnotations;

namespace EDeskOutSourcing.ViewModels
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage ="Old Password Required")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "New Password Required")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password Required")]
        [Compare("NewPassword",ErrorMessage ="New Password & Confirm Password Not Same")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
