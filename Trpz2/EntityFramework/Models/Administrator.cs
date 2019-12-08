namespace Trpz2.EntityFramework.Models
{
    public class Administrator
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Permission { get; set; }
    }

}
