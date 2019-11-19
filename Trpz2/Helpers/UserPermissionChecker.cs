using System.Collections.Generic;
using System.Linq;
using Trpz2.Models;

namespace Trpz2.Helpers
{
    public static class UserPermissionChecker
    {
        private static IEnumerable<User> registeredUsers = new List<User>()
        {
            new User(){ Login = "1", Password = "1", Permission = PermissionClass.Admin}
        };

        public static bool CheckPermission(User userToCheck)
        {
            if (registeredUsers.Contains(userToCheck))
                return true;
            return false;
        }

    }
}
