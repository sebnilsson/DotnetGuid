using System.Globalization;

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
                return () => Guid.Parse(settings.Parse);
            }

            if (settings.Version7)
            {
                var timestamp = TryParseTimestamp(settings.Version7Timestamp);

                return timestamp != null
                    ? () => Guid.CreateVersion7(timestamp.Value)
                    : () => Guid.CreateVersion7();
            }

            return s_newGuidFactory;
        }

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
    }
}
