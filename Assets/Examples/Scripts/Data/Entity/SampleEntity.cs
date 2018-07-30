using System;
using CAFU.Generics.Data.Entity;
using UnityEngine;

namespace Example.CAFU.Spawner.Data.Entity
{
    [Serializable]
    public class SampleEntity : IGenericEntity
    {
        public int Id;
        public Color Color;
    }
}