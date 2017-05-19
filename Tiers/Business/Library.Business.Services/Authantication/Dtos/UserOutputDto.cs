using System;
using System.Runtime.Serialization;

namespace Library.Business.Services.Authantication.Dtos
{
    [DataContract]
    [Serializable]
    public class UserOutputDto
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string Occupation { get; set; }

        [DataMember]
        public DateTime? LastLoginDate { get; set; }

        [DataMember]
        public string Role { get; set; }
    }
}