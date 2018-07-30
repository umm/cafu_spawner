using CAFU.Core.Presentation.View;
using CAFU.Spawner.Presentation.Presenter;
using CAFU.Spawner.Utility;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace CAFU.Spawner.Presentation.View
{
    public class AreaKiller : MonoBehaviour, IView
    {
        public BoxCollider2D Area;

        public void Start()
        {
            this.Area.OnTriggerEnter2DAsObservable()
                .Select(it =>
                    it.GetComponent<SpawnObject>() ??
                    it.GetComponentInParent<SpawnObject>())
                .Where(it => it != null)
                .Subscribe(it => this.GetPresenter<IMultipleSpawnerPresenter>().KillObject(it))
                .AddTo(this);
        }
    }
}