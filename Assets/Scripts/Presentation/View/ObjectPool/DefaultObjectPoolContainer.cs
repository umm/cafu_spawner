using CAFU.Core.Presentation.View;
using CAFU.Spawner.Presentation.Presenter;
using CAFU.Spawner.Utility;
using UnityEngine;

namespace CAFU.Spawner.Presentation.View
{
    public abstract class DefaultObjectPoolContainer : MonoBehaviour, IView
    {
        public abstract string ObjectPoolKey { get; }
        public Transform ParentTransform;
        public SpawnObject SpawnObject;

        private DefaultObjectPool ObjectPool => this.objectPool = this.objectPool ?? NewInstance();
        private DefaultObjectPool objectPool;

        void Start()
        {
            this.GetPresenter<IMultipleSpawnerPresenter>().LoadObjectPool(this.ObjectPoolKey, this.ObjectPool);
        }

        protected virtual DefaultObjectPool NewInstance()
        {
            return new DefaultObjectPool(this.SpawnObject, this.ParentTransform, this.ObjectPoolKey);
        }
    }
}