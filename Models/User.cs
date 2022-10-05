namespace KeyClock.API.Models
{
    public class User
    {
        public string id { get; set; }
        public long createdTimestamp { get; set; }
        public string username { get; set; }
        public bool enabled { get; set; }
        public bool totp { get; set; }
        public bool emailVerified { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public object[] disableableCredentialTypes { get; set; }
        public object[] requiredActions { get; set; }
        public int notBefore { get; set; }
        public Access access { get; set; }
    }
}
