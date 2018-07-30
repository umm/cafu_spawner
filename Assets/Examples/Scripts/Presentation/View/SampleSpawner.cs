using CAFU.Spawner.Presentation.View;
using Example.CAFU.Spawner.Application.Enuemrates;
using Example.CAFU.Spawner.Domain.Model;

namespace Example.CAFU.Spawner.Presentation.View
{
    public class SampleSpawner : RandomAreaFlowSpawner<SampleSpawnee, SampleModel>
    {
        public override string FlowKey => this.SampleType.ToString();
        public SampleType SampleType;
    }
}