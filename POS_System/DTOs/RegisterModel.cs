namespace POS_System.DTOs
{
    public class RegisterModel
    {
     
            public string UserName { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string PhoneNumber { get; set; }
            public string Password { get; set; } = null!;
        
    }
}
