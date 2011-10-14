using System;

namespace Modern.NETDeveloper.Domain
{
    public class SystemClock : ISystemClock
    {
        public DateTime Today()
        {
            return DateTime.Today;
        }
    }
}