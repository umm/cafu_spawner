using CAFU.Spawner.Presentation.View;
using Example.CAFU.Spawner.Application.Enuemrates;

namespace Example.CAFU.Spawner.Presentation.View
{
    public class SampleObjectPool : DefaultObjectPoolContainer
    {
        public override string ObjectPoolKey => this.SampleType.ToString();
        public SampleType SampleType;
    }
}