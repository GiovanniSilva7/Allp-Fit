namespace AllpFit.Library.Helpers
{
    public static class PasswordHelper
    {
        private const int workFactor = 10;

        /// <summary>
        /// Create an hash to the password
        /// </summary>
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password, workFactor);

        public static bool VerifyPassword(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
    }
}