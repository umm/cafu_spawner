using CAFU.Core.Presentation.Presenter;
using CAFU.Flow.Domain.UseCase;
using CAFU.Flow.Presentation.Presenter;
using CAFU.Spawner.Domain.UseCase;
using CAFU.Spawner.Presentation.Presenter;
using Example.CAFU.Spawner.Application.Enuemrates;
using Example.CAFU.Spawner.Data.Entity;
using Example.CAFU.Spawner.Domain.Model;
using Examples.Scripts.Domain.Translator;

namespace Example.CAFU.Spawner.Presentation.Presenter
{
    public class SamplePresenter : IMultipleSpawnerPresenter, IMultipleModelFlowPresenter
    {
        public class Factory : DefaultPresenterFactory<SamplePresenter>
        {
            protected override void Initialize(SamplePresenter instance)
            {
                base.Initialize(instance);
                instance.SampleModelMapUseCase = new ModelMapUseCase<SampleModel, SampleEntity, SampleEntityList, SampleModelTranslator>.Factory().Create();
                instance.MultipleModelFlowUseCase = new MultipleModelFlowUseCase.Factory().Create();
                instance.SpawnObjectPoolUseCase = new SpawnObjectPoolUseCase.Factory().Create();
            }
        }

        public IModelMapUseCase<SampleModel> SampleModelMapUseCase { get; private set; }
        public IMultipleModelFlowUseCase MultipleModelFlowUseCase { get; private set; }
        public ISpawnObjectPoolUseCase SpawnObjectPoolUseCase { get; private set; }
        
        public void Load()
        {
            this.LoadMultipleFlow();
            this.SampleModelMapUseCase.Load();
            this.MultipleModelFlowUseCase.LoadModel(this.SampleModelMapUseCase.Id2ModelMap);
        }

        public void Start()
        {
            this.StartMultipleFlow(SampleType.Circle.ToString());
            this.StartMultipleFlow(SampleType.Square.ToString());
        }
    }
}