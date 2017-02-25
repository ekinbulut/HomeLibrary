using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Services.Model
{
    public class BookView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Serie { get; set; }
        public int PublishDate { get; set; }
        public string Genre { get; set; }
        public int? No { get; set; }
        public string SkinType { get; set; }
        public string Shelf { get; set; }
        public int Rack { get; set; }
        public int UserId { get; set; }
    }
}
