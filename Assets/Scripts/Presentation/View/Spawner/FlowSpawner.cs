using CAFU.Core.Presentation.View;
using CAFU.Flow.Presentation.Presenter;
using UniRx;
using UnityEngine.EventSystems;

namespace CAFU.Spawner.Presentation.View
{
    public abstract class FlowSpawner<TModel> :
        UIBehaviour,
        IView,
        ISpawner<TModel>
    {
        public abstract void Spawn(TModel model);
        public abstract string FlowKey { get; }

        protected override void Start()
        {
            base.Start();
            this.ObserveModelFlow();
        }

        protected virtual void ObserveModelFlow()
        {
            this.GetPresenter<IMultipleModelFlowPresenter>().GetModelMultipleFlow<TModel>(this.FlowKey)
                .Subscribe(this.Spawn)
                .AddTo(this);
        }
    }
}