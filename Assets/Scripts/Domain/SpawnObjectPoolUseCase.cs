using System.Collections.Generic;
using CAFU.Core.Domain.UseCase;
using CAFU.Spawner.Utility;

namespace CAFU.Spawner.Domain.UseCase
{
    public interface ISpawnObjectPoolUseCase : IUseCase
    {
        void Load(string key, IObjectPool<SpawnObject> spawneeContainer);

        SpawnObject Spawn(string key);

        void Kill(string key, SpawnObject spawnee);

        IObjectPool<SpawnObject> GetObjectPool(string key);
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

        public IObjectPool<SpawnObject> GetObjectPool(string key)
        {
            return this.SpawnMap[key];
        }
    }
}