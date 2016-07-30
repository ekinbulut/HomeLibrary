using System;
using System.Runtime.Serialization;

namespace Library.Business.Dtos
{
    [DataContract]
    [Serializable]
    public class UserInputDto
    {
        [DataMember]
        public UserDto User { get; set; }
    }
}