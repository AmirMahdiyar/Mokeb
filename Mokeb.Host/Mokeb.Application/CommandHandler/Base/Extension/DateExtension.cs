using System.Globalization;

namespace Mokeb.Application.CommandHandler.Base.Extension
{
    public static class DateExtensions
    {
        public static List<DateOnly> GetRangeTo(this DateOnly startDate, DateOnly endDate)
        {
            var dates = new List<DateOnly>();
            for (var dt = startDate; dt < endDate; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }
            return dates;
        }
        public static DateOnly ToGregorianDateOnly(this string persianDate)
        {
            var parts = persianDate.Split('/');

            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            var pc = new PersianCalendar();
            var dateTime = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            return DateOnly.FromDateTime(dateTime);
        }
    }
}
