using Optional;
using Optional.Unsafe;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    public static class OptionEx
    {
        public static bool TrySome<T>(this Option<T> maybeThing, out T realThing)
        {
            if (maybeThing.HasValue)
            {
                realThing = maybeThing.ValueOrDefault();
                return true;
            }

            realThing = default(T);
            return false;
        }
    }
}
