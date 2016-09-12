using System.Runtime.Serialization;

namespace Library.Business.Services.Authentication.Dtos
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}