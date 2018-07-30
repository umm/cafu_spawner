using CAFU.Spawner.Utility;
using UniRx.Toolkit;
using UnityEngine;

namespace CAFU.Spawner.Presentation.View
{
    /// <summary>
    /// Default implementation of UniRx ObjectPool
    /// </summary>
    public class DefaultObjectPool : ObjectPool<SpawnObject>, IObjectPool<SpawnObject>
    {
        private SpawnObject prefab;
        private Transform parentTransform;
        private string objectPoolKey;

        public DefaultObjectPool(SpawnObject prefab, Transform parentTransform, string objectPoolKey)
        {
            this.prefab = prefab;
            this.parentTransform = parentTransform;
            this.objectPoolKey = objectPoolKey;
        }

        protected override SpawnObject CreateInstance()
        {
            var obj = GameObject.Instantiate(this.prefab, this.parentTransform, false);
            obj.ObjectPoolKey = this.objectPoolKey;
            return obj;
        }

        public virtual SpawnObject RentObject()
        {
            return this.Rent();
        }

        public virtual void ReturnObject(SpawnObject obj)
        {
            this.Return(obj);
        }
    }
}