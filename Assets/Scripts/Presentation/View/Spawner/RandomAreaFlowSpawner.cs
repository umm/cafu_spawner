using CAFU.Core.Presentation.View;
using CAFU.Spawner.Presentation.Presenter;
using UnityEngine;

namespace CAFU.Spawner.Presentation.View
{
    public abstract class RandomAreaFlowSpawner<TPrefabObject, TModel>
        : FlowSpawner<TModel>
        where TPrefabObject : Component, IInitializablePrefab<TModel>
    {
        public RectTransform RandomArea;

        public override void Spawn(TModel model)
        {
            var container = this.GetPresenter<IMultipleSpawnerPresenter>().SpawnObject(this.FlowKey);
            var obj = container.GetComponent<TPrefabObject>();
            obj.transform.SetRandomPositionInRectTransform(this.RandomArea);
            obj.Initialize(model);
        }
    }
}