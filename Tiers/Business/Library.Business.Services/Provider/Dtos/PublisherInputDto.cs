using System.Runtime.Serialization;

namespace Library.Business.Services.Provider.Dtos
{
    [DataContract]
    public class PublisherInputDto
    {
        [DataMember]
        public string PublisherName { get; set; }
        [DataMember]
        public string SeriesName { get; set; }
    }
}