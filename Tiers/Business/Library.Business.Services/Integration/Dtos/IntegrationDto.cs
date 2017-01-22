using System;
using System.Runtime.Serialization;

namespace Library.Business.Services.Integration.Dtos
{
    [DataContract]
    [Serializable]
    public class IntegrationDto
    {
        [DataMember]
        public byte[] ByteArray { get; set; }
        [DataMember]
        public string DocName { get; set; }
        [DataMember]
        public int UserId { get; set; }
    }
}