namespace aspfinal.Models.Forms
{
    public class LoginForm
    {
        public string? ReturnUrl { get; set; }

        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool KeepMeLoggedIn { get; set; }

    }
}
