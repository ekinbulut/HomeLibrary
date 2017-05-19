using System.Runtime.Serialization;

namespace Library.Business.Services.Authantication.Dtos
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Occupation { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}