using System;
using System.Threading;
using Anycraft.Features.Configs;
using Cysharp.Threading.Tasks;
using R3;

namespace Anycraft.Features.Frame.Models
{
    public abstract class BaseModel<TConfig>
        : BaseModel
        where TConfig : BaseSerializedConfig
    {
        private readonly ReactiveProperty<TConfig> _configObservable = new();

        public TConfig Config
        {
            get => _configObservable.Value;
            set => _configObservable.Value = value;
        }

        protected BaseModel()
            : base()
        {
            _configObservable.Subscribe();
            _configObservable.AddTo(CtsToken);
        }

        protected virtual void OnConfigChanged(TConfig config)
        {
        }
    }

    public abstract class BaseModel
        : IDisposable
    {
        private readonly CancellationTokenSource _cts = new();

        public CancellationToken CtsToken => _cts.Token;

        protected BaseModel()
        {
        }

        public virtual void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}