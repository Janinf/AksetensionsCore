using System;

namespace AksetensionsCore
{
    public static class StandardFunctions
    {
        public static TOutput Map<TSource, TOutput>(this TSource source, Func<TSource,TOutput> block)
        {
            return block.CheckNotNull(nameof(block)).Invoke(source.CheckNotNull());
        }

        public static TSource With<TSource>(this TSource source, Action<TSource> block)
        {
            block.CheckNotNull(nameof(block)).Invoke(source.CheckNotNull());
            return source;
        }

        public static TSource Also<TSource>(this TSource source, Action block)
        {
            source.CheckNotNull();
            block.CheckNotNull(nameof(block)).Invoke();
            return source;
        }

        public static TOutput Other<TSource, TOutput>(this TSource source, Func<TOutput> block)
        {
            source.CheckNotNull();
            return block.CheckNotNull(nameof(block)).Invoke();
        }
    }
}