namespace CAFU.Spawner.Presentation.View
{
    public abstract class InvalidObjectPoolContainer : DefaultObjectPoolContainer
    {
        protected override DefaultObjectPool NewInstance()
        {
            return new InvalidObjectPool(this.SpawnObject, this.ParentTransform, this.ObjectPoolKey);
        }
    }
}