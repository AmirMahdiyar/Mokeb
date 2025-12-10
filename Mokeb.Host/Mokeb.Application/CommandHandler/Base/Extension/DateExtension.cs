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
    }
}
