namespace Entities.ConfigurationModels
{
    public class JwtConfiguration
    {
        #region Properties

        public string Section { get; set; } = "JwtSettings";
        public string? ValidIssuer { get; set; }
        public string? ValidAudience { get; set; }
        public string? Expires { get; set; }

        #endregion Properties
    }
}