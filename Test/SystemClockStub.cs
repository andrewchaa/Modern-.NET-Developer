using System;
using Modern.NETDeveloper.Domain;

namespace Test
{
    public class SystemClockStub : ISystemClock
    {
        public SystemClockStub(DateTime testToday)
        {
            TestToday = testToday;
        }

        public DateTime TestToday { get; set; }
        public DateTime Today()
        {
            return TestToday;
        }
    }
}