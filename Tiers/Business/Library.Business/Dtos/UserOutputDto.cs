using System;
using System.Runtime.Serialization;

namespace Library.Business.Dtos
{
    [DataContract]
    [Serializable]
    public class UserOutputDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Occupation { get; set; }
        [DataMember]
        public DateTime? LastLoginDate { get; set; }
    }
}