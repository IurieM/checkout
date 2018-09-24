namespace Identity.Api.Settings
{
    public class AuthenticationSettings
    {
        public string Authority { get; set; }

        public string Audience { get; set; }

        public int ExpireInMinutes { get; set; }

        public string SecretKey { get; set; }
    }
}
