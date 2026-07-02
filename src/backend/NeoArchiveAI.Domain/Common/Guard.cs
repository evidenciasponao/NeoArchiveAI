using NeoArchiveAI.Domain.Exceptions;

namespace NeoArchiveAI.Domain.Common;

public static class Guard
{
    public static void AgainstNullOrWhiteSpace(string? value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException($"{parameterName} is required.");
    }

    public static void AgainstEmptyGuid(Guid value, string parameterName)
    {
        if (value == Guid.Empty)
            throw new DomainException($"{parameterName} is required.");
    }

    public static void AgainstNegativeOrZero(long value, string parameterName)
    {
        if (value <= 0)
            throw new DomainException($"{parameterName} must be greater than zero.");
    }
}
