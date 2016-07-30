using System.ComponentModel;

namespace Library.Mvc.Models
{
    public class PublisherModel
    {
        [DisplayName("Publisher")]
        public string PublisherName { get; set; }
        [DisplayName("Series")]
        public string SeriesName { get; set; }
    }
}
