using System.ComponentModel.DataAnnotations;

namespace server_travel.Dtos.Authentication
{
    public class UserRegisterRequest
    {
        //public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public string? Email { get; set; }
        [Required]

        public string? Password { get; set; }

    }
}
