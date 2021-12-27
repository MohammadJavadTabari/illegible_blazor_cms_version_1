using System.ComponentModel.DataAnnotations;

namespace illShop.Shared.Dto.DtosRelatedIdentity
{
    public class LoginModelDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
