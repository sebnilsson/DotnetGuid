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

        private readonly string _format;

        public GuidGenerator(GuidApp app)
        {
            _app = app ?? throw new ArgumentNullException(nameof(app));

            _guidFactory = !app.Empty ? s_newGuidFactory : s_emptyGuidFactory;
            _format = GuidFormatResolver.GetFormat(app);
        }

        public IEnumerable<string> GenerateGuids()
        {
            for (var i = 0; i < _app.Count; i++)
            {
                yield return GenerateGuid();
            }
        }

        private string GenerateGuid()
        {
            var guid = _guidFactory();

            var result = guid.ToString(_format);

            result = _app.UpperCase ? result.ToUpperInvariant() : result;

            return result;
        }
    }
}
