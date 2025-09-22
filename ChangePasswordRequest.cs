namespace LoginSystem.DTO
{
    public class ChangePasswordRequest
    {
        public string CurrentPassword { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

    }
}
