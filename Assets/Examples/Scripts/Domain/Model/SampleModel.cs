using CAFU.Core.Domain.Model;
using CAFU.Flow.Utility;
using UnityEngine;

namespace Example.CAFU.Spawner.Domain.Model
{
    public class SampleModel : IModel, IPrimaryId
    {
        public int PrimaryId { get; set; }
        public Color Color { get; set; }
    }
}