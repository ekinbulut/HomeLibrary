using System.ComponentModel;

namespace Library.Mvc.Models
{
    public class AuthorModel
    {
        [DisplayName("Author Name")]
        public string Name { get; set; }
    }
}
