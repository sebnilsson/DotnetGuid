using System;
using System.Collections.Generic;

namespace DotnetGuid
{
    public class GuidGenerator
    {
        private static readonly Func<Guid> s_newGuidFactory = () => Guid.NewGuid();

        private static readonly Func<Guid> s_emptyGuidFactory = () => Guid.Empty;

        private readonly GuidApp _app;

        private readonly Func<Guid> _guidFactory;

        private readonly GuidFormatter _guidFormatter;

        public GuidGenerator(GuidApp app)
        {
            _app = app ?? throw new ArgumentNullException(nameof(app));

            _guidFactory = !app.Empty ? s_newGuidFactory : s_emptyGuidFactory;
            _guidFormatter = GuidFormatterResolver.GetFormatter(app);
        }

        public IEnumerable<string> GenerateGuids()
        {
            for (var i = 0; i < _app.Count; i++)
            {
                yield return GetGuid();
            }
        }

        private string GetGuid()
        {
            var guid = _guidFactory();

            var formattedGuid = GetFormattedGuid(guid);

            var modifiedGuid = GetModifiedGuid(formattedGuid);

            return modifiedGuid;
        }

        private string GetFormattedGuid(Guid guid)
        {
            return _guidFormatter.GetResult(guid);
        }

        private string GetModifiedGuid(string formattedGuid)
        {
            var modifiedGuid = formattedGuid;

            if (_guidFormatter.CanBeCased && _app.LowerCase)
            {
                modifiedGuid = modifiedGuid.ToLowerInvariant();
            }
            if (_guidFormatter.CanBeCased && _app.UpperCase)
            {
                modifiedGuid = modifiedGuid.ToUpperInvariant();
            }

            return modifiedGuid;
        }
    }
}
