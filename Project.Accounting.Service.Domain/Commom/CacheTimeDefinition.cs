namespace Project.Accounting.Service.Domain.Commom
{
    public static class CacheTimeDefinition
    {
        public static TimeSpan OneYear() => new(360, 0, 0, 0);
        public static TimeSpan OneMinute() => new(0, 1, 0);
        public static TimeSpan OneHour() => new(1, 0, 0);
        public static TimeSpan FiveMinutes() => new(0, 5, 0);
    }
}
