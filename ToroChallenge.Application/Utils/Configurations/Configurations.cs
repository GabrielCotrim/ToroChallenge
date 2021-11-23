using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroChallenge.Application.Utils.Configurations
{
    public static class Configurations
    {
        public static string GetDefaultConnectionString { get; } = "Server=192.168.0.114,1433;Database=investimentos;UID=sa;PWD=Pwdsafe@123;";
    }
}
