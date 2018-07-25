namespace CAFU.Spawner.Presentation.View
{
    public interface IInitializablePrefab<TModel>
    {
        void Initialize(TModel model);
    }
}