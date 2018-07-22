using EFCoreSamples.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;

namespace EFCoreSamples.Converters
{
    public class GenderToStringConverter : ValueConverter<Gender?, string>
    {
        private const string GenderFemale = "F";
        private const string GenderMale = "M";

        public GenderToStringConverter() : base(ToProviderExpression(), FromProviderExpression())
        {
        }

        private static Expression<Func<Gender?, string>> ToProviderExpression() => modelValue => ToProvider(modelValue);

        private static Expression<Func<string, Gender?>> FromProviderExpression() => providerValue => FromProvider(providerValue);

        private static string ToProvider(Gender? modelValue)
        {
            if (!modelValue.HasValue) return null;
            switch (modelValue.Value)
            {
                case Gender.Female: return GenderFemale;
                case Gender.Male: return GenderMale;
                default: return null;
            }
        }

        private static Gender? FromProvider(string providerValue)
        {
            if (string.IsNullOrWhiteSpace(providerValue)) return null;
            switch (providerValue)
            {
                case GenderFemale: return Gender.Female;
                case GenderMale: return Gender.Male;
                default: return null;
            }
        }
    }
}
