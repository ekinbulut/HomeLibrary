using System;
using System.Runtime.Serialization;

namespace Library.Business.Services.Book.Dtos
{
    [DataContract]
    [Serializable]
    public class BookInputDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Author { get; set; }
        [DataMember]
        public int Publisher { get; set; }
        [DataMember]
        public int Serie { get; set; }
        [DataMember]
        public int PublishDate { get; set; }
        [DataMember]
        public int Genre { get; set; }
        [DataMember]
        public string No { get; set; }
        [DataMember]
        public int SkinType { get; set; }
        [DataMember]
        public int Shelf { get; set; }
        [DataMember]
        public int Rack { get; set; }
    }
}