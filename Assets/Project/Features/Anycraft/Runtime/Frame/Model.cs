using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using Anycraft.Frame.Configs;

namespace Anycraft.Frame
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