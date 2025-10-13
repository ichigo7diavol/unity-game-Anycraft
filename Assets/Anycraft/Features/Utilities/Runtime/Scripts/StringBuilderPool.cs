using System.Collections.Concurrent;
using System.Text;

namespace Anycraft.Features.Utilities
{
    public static class StringBuilderPool
    {
        private static readonly ConcurrentBag<StringBuilder> _pool = new();
        private const int MaxPoolSize = 64;

        public static PooledStringBuilder Rent()
        {
            return new PooledStringBuilder
            (
                _pool.TryTake(out var sb)
                    ? sb
                    : new StringBuilder()
            );
        }

        private static void Return(StringBuilder sb)
        {
            if (sb == null) return;
            sb.Clear();

            if (_pool.Count < MaxPoolSize)
                _pool.Add(sb);
        }

        public readonly ref struct PooledStringBuilder
        {
            private readonly StringBuilder _builder;
            public StringBuilder Builder => _builder;

            public PooledStringBuilder(StringBuilder builder)
            {
                _builder = builder;
            }

            public override string ToString() => _builder.ToString();

            public void Dispose() => Return(_builder);
        }
    }
}