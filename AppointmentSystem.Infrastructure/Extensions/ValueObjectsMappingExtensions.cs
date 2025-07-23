using AppointmentSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppointmentSystem.Infrastructure.Extensions
{
    public static class ValueObjectMappingExtensions
    {
        public static PropertyBuilder<Email> HasEmailConversion(this PropertyBuilder<Email> builder)
        {
            var converter = new ValueConverter<Email, string>(
                email => email.Value,
                value => new Email(value));

            return builder.HasConversion(converter)
                          .HasMaxLength(100)
                          .IsRequired();
        }

        public static PropertyBuilder<PhoneNumber> HasPhoneNumberConversion(this PropertyBuilder<PhoneNumber> builder)
        {
            var converter = new ValueConverter<PhoneNumber, string>(
                phone => phone.Value,
                value => new PhoneNumber(value));

            return builder.HasConversion(converter)
                          .HasMaxLength(20)
                          .IsRequired(false);  // if phone number not required
        }


    }
}
