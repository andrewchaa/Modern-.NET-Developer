using System;

namespace Modern.NETDeveloper.Domain
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
        public static Func<DateTime> Today = () => DateTime.Today;
    }
}