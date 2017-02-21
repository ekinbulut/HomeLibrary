using System;

namespace Library.UI.Services.Model
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
