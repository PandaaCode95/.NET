namespace UniversityBackend.Models.DataModels
{
    public class JwtSettings
    {
        public bool ValidateUserSignKey { get; set; }
        public string IssueSigningKey { get; set; } =String.Empty; 
        public bool ValidateIssuer { get; set; } = true;
        public string? ValidIssuer { get; set; }
        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudience { get; set; }
        public bool RequireExpiration { get; set; }
        public bool ValidateLifeTime { get; set; }


    }
}
