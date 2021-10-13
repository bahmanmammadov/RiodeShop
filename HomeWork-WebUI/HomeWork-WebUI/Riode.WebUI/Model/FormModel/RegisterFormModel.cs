using System.ComponentModel.DataAnnotations;

namespace Riodetask.Model.FormModel
{
    public class RegisterFormModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required , DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required,Compare("Password")]
        public string CheckPassword { get; set; }


    }
}
