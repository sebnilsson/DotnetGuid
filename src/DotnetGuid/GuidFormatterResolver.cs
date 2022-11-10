using System;

namespace DotnetGuid
{
    internal static class GuidFormatterResolver
    {
        public static GuidFormatter GetFormatter(GuidCommand.Settings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            return settings switch
            {
                { Format: GuidCommand.Settings.GuidFormat.B64 } => GuidFormatter.CreateForBase64(trim: true),
                { Format: GuidCommand.Settings.GuidFormat.B64F } => GuidFormatter.CreateForBase64(trim: false),
                { Format: GuidCommand.Settings.GuidFormat.N } => GuidFormatter.CreateForToString("N"),
                { Format: GuidCommand.Settings.GuidFormat.H } => GuidFormatter.CreateForToString("D"),
                { Format: GuidCommand.Settings.GuidFormat.HB } => GuidFormatter.CreateForToString("B"),
                { Format: GuidCommand.Settings.GuidFormat.HP } => GuidFormatter.CreateForToString("P"),
                { Format: GuidCommand.Settings.GuidFormat.X } => GuidFormatter.CreateForToString("X"),
                _ => GuidFormatter.CreateDefault()
            };
        }
    }
}
