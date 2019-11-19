namespace Trpz2.Models
{
    public class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public PermissionClass Permission { get; set; }


        public override bool Equals(object obj)
        {
            var item = obj as User;

            if (item == null)
            {
                return false;
            }

            return string.Equals(this.Login, item.Login) && string.Equals(this.Password, item.Password) && this.Permission == item.Permission;
        }
    }

    public enum PermissionClass
    {
        User = 1,
        Admin = 2,
        Moderator = 3
    }
}
