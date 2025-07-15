namespace Samba.WebApi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PinCode { get; set; }
        public string UserRole { get; set; }
    }

    public class LoginRequestDto
    {
        public string PinCode { get; set; }
    }

    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public UserDto User { get; set; }
        public string Message { get; set; }
    }
}