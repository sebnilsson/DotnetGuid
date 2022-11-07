using System;

namespace DotnetGuid
{
    internal class GuidFormatter
    {
        private readonly Func<Guid, string> _factory;

        public GuidFormatter(Func<Guid, string> factory, bool canBeCased = true)
        {
            _factory = factory;
            CanBeCased = canBeCased;
        }

        public bool CanBeCased { get; }

        public string GetResult(Guid guid)
        {
            return _factory(guid);
        }

        public static GuidFormatter CreateForBase64(bool trim)
        {
            return new GuidFormatter(
                x =>
                {
                    var base64 = Convert.ToBase64String(x.ToByteArray());
                    return trim ? base64.TrimEnd('=') : base64;
                },
                canBeCased: false);
        }

        public static GuidFormatter CreateDefault()
        {
            return new GuidFormatter(x => x.ToString());
        }

        public static GuidFormatter CreateForToString(string format)
        {
            return new GuidFormatter(x => x.ToString(format));
        }
    }
}
