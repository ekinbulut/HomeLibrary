using System;
using Newtonsoft.Json;

namespace Library.Api.Objects
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class BookInputDto
    {
        public string Name { get; set; }

        public int Author { get; set; }

        public int Publisher { get; set; }

        public int Serie { get; set; }

        public int PublishDate { get; set; }

        public int Genre { get; set; }

        public string No { get; set; }

        public int SkinType { get; set; }

        public int Shelf { get; set; }

        public int Rack { get; set; }

        public int UserId { get; set; }
    }
}