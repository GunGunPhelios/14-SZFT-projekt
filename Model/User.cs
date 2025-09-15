using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginSystem.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength (100)]

        public string Email { get; set; }

        [Required]
        [StringLength (100)]
        public string PasswordHash { get; set; }

        [StringLength (100)]
        public string? Firstname { get; set; }

        [StringLength(100)]
        public string Lastname { get; set; }

        [StringLength (100)]
         
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public bool EmailConfirmed { get; set; } = false;

        public DateTime CreatedAt { get; set; } =DateTime.Now;
        public DateTime LastLoginAt { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [StringLength(50)]
        public string Role { get; set; } = "User";

        [StringLength(500)]
        // Refresh token kezeléshez
       
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        [StringLength(255)]

        public string? EmailConfirmationToken { get; set; }

        [StringLength(255)]

        public string? PasswordResetToken { get;set; }
        public DateTime? PasswordResetTokenExpiry {  get; set; }

        [NotMapped]

        public string FullName => $"{Firstname} {Lastname}".Trim();


    }
}
