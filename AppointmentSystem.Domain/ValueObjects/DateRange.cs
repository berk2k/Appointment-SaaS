namespace AppointmentSystem.Domain.ValueObjects
{
    public class DateRange : ValueObject
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        private DateRange() { }

        public DateRange(DateTime start, DateTime end)
        {
            if (end <= start)
                throw new ArgumentException("End date must be after start date");

            Start = start;
            End = end;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }
    }

}
