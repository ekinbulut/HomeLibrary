using System;
using Newtonsoft.Json;

namespace Library.Api.Objects
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string Serie { get; set; }

        public int PublishDate { get; set; }

        public string Genre { get; set; }

        public string No { get; set; }

        public string SkinType { get; set; }

        public string Shelf { get; set; }

        public int Rack { get; set; }

        public DateTime CreatedDateTime { get; set; }

    }
}