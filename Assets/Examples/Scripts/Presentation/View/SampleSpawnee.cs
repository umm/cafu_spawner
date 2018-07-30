using CAFU.Spawner.Presentation.View;
using CAFU.Spawner.Utility;
using Example.CAFU.Spawner.Domain.Model;
using UnityEngine.UI;

namespace Example.CAFU.Spawner.Presentation.View
{
    public class SampleSpawnee : SpawnObject, IInitializablePrefab<SampleModel>
    {
        public Image Image;

        public void Initialize(SampleModel model)
        {
            this.Image.color = model.Color;
        }
    }
}