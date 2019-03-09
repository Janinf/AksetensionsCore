using System;

namespace AksetensionsCore
{
    public static class PropertyPredicates
    {
        public static bool IsNull<TSource>(this TSource source) => source == null;

        public static bool IsNotNull<TSource>(this TSource source) => source != null;

        public static bool IsNullOrEmpty(this string source) => string.IsNullOrEmpty(source);

        public static bool IsNullOrWhiteSpace(this string source) => string.IsNullOrWhiteSpace(source);
    }
}