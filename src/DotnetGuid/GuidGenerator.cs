using System;
using System.Collections.Generic;

namespace DotnetGuid
{
    public class GuidGenerator
    {
        private static readonly Func<Guid> GuidFactory = () => Guid.NewGuid();

        private static readonly Func<Guid> EmptyGuidFactory = () => Guid.Empty;

        private readonly GuidApp _app;

        private readonly Func<Guid> _factory;

        private readonly string _format;

        public GuidGenerator(GuidApp app)
        {
            _app = app ?? throw new ArgumentNullException(nameof(app));

            _factory = !app.Empty ? GuidFactory : EmptyGuidFactory;
            _format = GuidFormatResolver.GetFormat(app);
        }

        public IEnumerable<string> GenerateGuids()
        {
            for (int i = 0; i < _app.Count; i++)
            {
                yield return GenerateGuid();
            }
        }

        private string GenerateGuid()
        {
            var guid = _factory();

            var result = guid.ToString(_format);

            result = _app.UpperCase ? result.ToUpperInvariant() : result;

            return result;
        }
    }
}