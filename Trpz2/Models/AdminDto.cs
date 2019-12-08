namespace Trpz2.Models
{
    public class AdminDto
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public PermissionClass Permission { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as AdminDto;

            if (item == null)
            {
                return false;
            }

            return string.Equals(this.Username, item.Username) && string.Equals(this.Password, item.Password) && this.Permission == item.Permission;
        }
    }

}
