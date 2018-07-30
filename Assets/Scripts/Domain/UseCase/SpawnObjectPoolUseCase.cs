using System.Collections.Generic;
using CAFU.Core.Domain.UseCase;
using CAFU.Spawner.Utility;

namespace CAFU.Spawner.Domain.UseCase
{
    public interface ISpawnObjectPoolUseCase : IUseCase
    {
        /// <summary>
        /// Set ObjectPool as specified key
        /// </summary>
        /// <param name="key">Key to specify objectpool</param>
        /// <param name="spawneeContainer">Container to hold spawnee</param>
        void Load(string key, IObjectPool<SpawnObject> spawneeContainer);

        /// <summary>
        /// Spawn object by using key.
        /// </summary>
        /// <param name="key">Key to specify objectpool</param>
        /// <returns></returns>
        SpawnObject Spawn(string key);

        /// <summary>
        /// Kill spawnee object
        /// </summary>
        /// <param name="key">Key to specify objectpool</param>
        /// <param name="spawnee">Object to return into ObjectPool</param>
        void Kill(string key, SpawnObject spawnee);
    }

    public class SpawnObjectPoolUseCase : ISpawnObjectPoolUseCase
    {
        public class Factory : DefaultUseCaseFactory<SpawnObjectPoolUseCase>
        {
            protected override void Initialize(SpawnObjectPoolUseCase instance)
            {
                base.Initialize(instance);
                instance.SpawnMap = new Dictionary<string, IObjectPool<SpawnObject>>();
            }
        }

        private IDictionary<string, IObjectPool<SpawnObject>> SpawnMap { get; set; }

        public void Load(string key, IObjectPool<SpawnObject> spawneeContainer)
        {
            this.SpawnMap[key] = spawneeContainer;
        }

        public SpawnObject Spawn(string key)
        {
            return this.SpawnMap[key].RentObject();
        }

        public void Kill(string key, SpawnObject spawnee)
        {
            this.SpawnMap[key].ReturnObject(spawnee);
        }
    }
}