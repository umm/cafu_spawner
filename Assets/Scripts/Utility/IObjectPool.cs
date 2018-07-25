using UnityEngine;

namespace CAFU.Spawner.Utility
{
    public interface IObjectPool<TPrefabObject>
        where TPrefabObject : Component
    {
        /// <summary>
        /// Get object from pool
        /// </summary>
        /// <returns></returns>
        TPrefabObject RentObject();

        /// <summary>
        /// Return object to pool
        /// </summary>
        /// <param name="obj"></param>
        void ReturnObject(TPrefabObject obj);
    }
}