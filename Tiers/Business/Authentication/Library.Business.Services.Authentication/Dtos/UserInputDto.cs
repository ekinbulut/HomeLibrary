using System;
using System.Runtime.Serialization;

namespace Library.Business.Services.Authentication.Dtos
{
    [DataContract]
    [Serializable]
    public class UserInputDto
    {
        [DataMember]
        public UserDto User { get; set; }
    }
}