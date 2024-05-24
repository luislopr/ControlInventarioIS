using System.ComponentModel.DataAnnotations;

namespace ControlInventario.WebApi.Models
{
    public class DtoCreateUserRequestModel
    {
        public int Parent { get; set; }
        public int Class { get; set; }
        public string UserLogin { get; set; }
        public string UserFullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
    }

    public class DtoUpdateUserRequestModel : DtoCreateUserRequestModel
    {
        [Required]
        public int Id { get; set; }
        public bool Status { get; set; } = true;
    }
}