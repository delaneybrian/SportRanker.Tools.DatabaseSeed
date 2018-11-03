using System;
using System.Linq;

namespace SportRanker.Tools.DatabaseSeed.Application
{
    internal static class StringEx
    {
        public static string[] ToCsvArray(this string s)
        {
            return s
                .Split(',')
                .Select(x => x.Clean())
                .ToArray();
        }

        public static string Clean(this string s)
        {
            if (s == null)
                return string.Empty;

            var cleaned = s.Trim();

            if (cleaned.Equals("NULL", StringComparison.InvariantCultureIgnoreCase))
                return string.Empty;

            return cleaned;
        }

        public static long? ToLong(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            var valid = long.TryParse(s, out var result);

            return valid ? result : default(long?);
        }
    }
}
