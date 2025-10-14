using System;
using System.Threading;
using Anycraft.FluentValidationExtensions.Configs;
using Cysharp.Threading.Tasks;
using R3;

namespace Anycraft.FluentValidationExtensions.Frame
{
    public abstract class BaseModel<TConfig> : IDisposable
        where TConfig : IConfig
    {
        private readonly CancellationTokenSource _cts = new();

        private readonly Subject<TConfig> _configSubject = new();

        public CancellationToken Token => _cts.Token;

        public BaseModel()
        {
            _configSubject.AddTo(Token);
        }

        public void SetConfig(TConfig config)
        {
            _configSubject.OnNext(config);
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        protected virtual void OnConfigChanged(TConfig config) { }
    }
}