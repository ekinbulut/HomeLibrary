using System;
using System.Runtime.Serialization;

namespace Library.Business.Services.Integration.Dtos
{
    [DataContract]
    [Serializable]
    public class IntegrationInputDto
    {
        [DataMember]
        public IntegrationDto IntegrationDto { get; set; }
    }
}