using System.Linq;
using CAFU.Core.Presentation.View;
using CAFU.Spawner.Presentation.Presenter;
using CAFU.Spawner.Utility;
using UnityEngine;

namespace CAFU.Spawner.Presentation.View
{
    public class XPositionKiller : MonoBehaviour, IView
    {
        public Transform SpawnObjectParent;
        public bool KillHigherPosition = true;

        void Update()
        {
            // Maybe slow when objects count increased
            var objects = this.SpawnObjectParent
                .GetComponentsInChildren<SpawnObject>()
                .Where(it =>
                    this.KillHigherPosition
                        ? it.transform.position.x > this.transform.position.x
                        : it.transform.position.x < this.transform.position.x
                );

            foreach (var obj in objects)
            {
                this.GetPresenter<IMultipleSpawnerPresenter>().KillObject(obj);
            }
        }
    }
}