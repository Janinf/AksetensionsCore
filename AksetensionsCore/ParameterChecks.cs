using System;

namespace AksetensionsCore
{
    public static class ParameterChecks
    {
        public static TSource CheckNotNull<TSource>(this TSource source, string parameterName = "source")
        {
            if (source == null) throw new ArgumentNullException(parameterName);

            return source;
        }

        public static string CheckNotNullOrEmpty(this string source, string propertyName = "source")
        {
            if (string.IsNullOrEmpty(source)) throw new ArgumentException($"{propertyName} cannot be null or empty.");

            return source;
        }

        public static string CheckNotNullOrWhiteSpace(this string source, string propertyName = "source")
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentException($"{propertyName} cannot be null, empty or consist of only whitespace characters.");

            return source;
        }
    }
}