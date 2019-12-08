using System.Collections.Generic;
using System.Linq;
using Trpz2.Models;

namespace Trpz2.Helpers
{
    public static class UserPermissionChecker
    {
        private static IEnumerable<AdminDto> registeredUsers = new List<AdminDto>()
        {
            new AdminDto(){ Username = "Misha", Password = "1", Permission = PermissionClass.Admin}
        };

        public static bool CheckPermission(AdminDto userToCheck)
        {
            if (registeredUsers.Contains(userToCheck))
                return true;
            return false;
        }

    }
}
