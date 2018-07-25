using CAFU.Spawner.Utility;
using UnityEngine;

namespace CAFU.Spawner.Presentation.View
{
    /// <summary>
    /// Not pooling. just destroy & instantiate
    /// </summary>
    public class InvalidObjectPool : DefaultObjectPool
    {
        public InvalidObjectPool(SpawnObject prefab, Transform parentTransform, string objectPoolKey)
            : base(prefab, parentTransform, objectPoolKey)
        {
        }

        public override SpawnObject RentObject()
        {
            return CreateInstance();
        }

        public override void ReturnObject(SpawnObject obj)
        {
            GameObject.Destroy(obj.gameObject);
        }
    }
}