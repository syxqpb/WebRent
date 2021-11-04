using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest2ebt.UI.AppConfiguration
{
    public static class RolesNames
    {
        public const string Admin = "admin";
        public const string User = "user";
        public const string AdminOrUser = Admin + "," + User;
    }
}
