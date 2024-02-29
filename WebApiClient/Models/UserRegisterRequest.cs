namespace WebApi.Models
{
    public class UserRegisterRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}