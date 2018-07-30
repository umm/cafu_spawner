using System;
using CAFU.Generics.Data.Entity;
using UnityEngine;

namespace Example.CAFU.Spawner.Data.Entity
{
    [Serializable]
    [CreateAssetMenu(fileName = "SampleEntityList", menuName = "Spawner/SampleEntityList")]
    public class SampleEntityList : ScriptableObjectGenericEntityList<SampleEntity>
    {
    }
}