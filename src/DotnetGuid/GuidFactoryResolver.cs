#if NET9_0_OR_GREATER
using System.Globalization;
#endif

namespace DotnetGuid
{
    internal static class GuidFactoryResolver
    {
        private static readonly Func<Guid> s_newGuidFactory = () => Guid.NewGuid();

        private static readonly Func<Guid> s_emptyGuidFactory = () => Guid.Empty;

        public static Func<Guid> Create(GuidCommandSettings settings)
        {
            if (settings.Empty)
            {
                return s_emptyGuidFactory;
            }

            if (!string.IsNullOrWhiteSpace(settings.Parse))
            {
                return () => Guid.TryParse(settings.Parse, out var guid) ? guid : s_emptyGuidFactory();
            }

#if NET9_0_OR_GREATER
            if (settings.Version7)
            {
                var timestamp = TryParseTimestamp(settings.Version7Timestamp);

                return timestamp != null
                    ? () => Guid.CreateVersion7(timestamp.Value)
                    : () => Guid.CreateVersion7();
            }
#endif

            return s_newGuidFactory;
        }

#if NET9_0_OR_GREATER
        private static DateTimeOffset? TryParseTimestamp(string timestamp)
        {
            if (string.IsNullOrWhiteSpace(timestamp))
            {
                return null;
            }

            return DateTimeOffset.TryParse(timestamp, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result)
                ? result
                : null;
        }
#endif
    }
}
