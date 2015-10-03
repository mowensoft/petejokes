using System;

namespace PeteJokes.Infrastructure
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}
