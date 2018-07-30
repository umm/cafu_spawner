using CAFU.Core.Presentation.View;
using CAFU.Spawner.Presentation.Presenter;
using Example.CAFU.Spawner.Presentation.Presenter;

namespace Example.CAFU.Spawner.Presentation.View
{
    public class Controller : Controller<Controller, SamplePresenter, SamplePresenter.Factory>
    {
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();

            this.GetPresenter<SamplePresenter>().Load();
            this.GetPresenter<SamplePresenter>().Start();
        }
    }
}