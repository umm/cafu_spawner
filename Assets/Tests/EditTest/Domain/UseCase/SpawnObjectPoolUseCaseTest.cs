using CAFU.Spawner.Domain.UseCase;
using CAFU.Spawner.Utility;
using NUnit.Framework;
using UnityEngine;

namespace EditTest.CAFU.Spawner.Domain.UseCase
{
    class DummyObjectPool : IObjectPool<SpawnObject>
    {
        public SpawnObject DummyObject { get; set; }
        public int RentObjectCount = 0;
        public int ReturnObjectCount = 0;

        public SpawnObject RentObject()
        {
            this.RentObjectCount++;
            return this.DummyObject;
        }

        public void ReturnObject(SpawnObject obj)
        {
            this.ReturnObjectCount++;
            this.DummyObject = obj;
        }
    }

    public class SpawnObjectPoolUseCaseTest
    {
        [Test]
        public void SpawnTest()
        {
            var usecase = new SpawnObjectPoolUseCase.Factory().Create();
            var pool = new DummyObjectPool();
            var dummy = this.CreateDummy();
            dummy.ObjectPoolKey = "dummy";
            pool.DummyObject = dummy;
            
            usecase.Load("sample", pool);
            Assert.AreEqual(0, pool.RentObjectCount);
            Assert.AreEqual(0, pool.ReturnObjectCount);
            
            var sample = usecase.Spawn("sample");
            Assert.AreEqual("dummy", sample.ObjectPoolKey);
            Assert.AreEqual(1, pool.RentObjectCount);
            Assert.AreEqual(0, pool.ReturnObjectCount);
            
            usecase.Kill("sample", sample);
            Assert.AreEqual(1, pool.RentObjectCount);
            Assert.AreEqual(1, pool.ReturnObjectCount);
        }
        
        private SpawnObject CreateDummy()
        {
            var obj = new GameObject();
            return obj.AddComponent<SpawnObject>();
        }
    }
}