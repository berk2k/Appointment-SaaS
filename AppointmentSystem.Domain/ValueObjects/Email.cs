namespace AppointmentSystem.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email() { }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !IsValidEmail(value))
                throw new ArgumentException("Invalid email format");

            Value = value;
        }

        private bool IsValidEmail(string email)
        {

            return email.Contains("@");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value.ToLower();
        }

        public override string ToString() => Value;
    }

}
