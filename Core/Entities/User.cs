using MongoDB.Bson.Serialization.Attributes;

namespace Core;

public class User : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string DisplayName { get; set; }
    public string Password { get; set; }
    public string[] PhoneNumbers { get; set; }
    public string DefaultPhoneNumber { get; set; }
    public string[] Roles { get; set; }
    public bool EmailVerified { get; set; }
    public bool Active { get; set; }
    public bool TwoFactorEnabled { get; set; } 
    public string HostDomain { get; set; }
}
