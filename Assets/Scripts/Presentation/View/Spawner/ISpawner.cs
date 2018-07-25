namespace CAFU.Spawner.Presentation.View
{
    public interface ISpawner<TModel>
    {
        void Spawn(TModel model);
    }
}