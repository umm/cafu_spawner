using CAFU.Core.Presentation.Presenter;
using CAFU.Spawner.Domain.UseCase;
using CAFU.Spawner.Utility;

namespace CAFU.Spawner.Presentation.Presenter
{
    public interface IMultipleSpawnerPresenter : IPresenter
    {
        ISpawnObjectPoolUseCase SpawnObjectPoolUseCase { get; }
    }

    public static class IMultipleSpawnerPresenterExtension
    {
        public static void LoadObjectPool(this IMultipleSpawnerPresenter presenter, string key, IObjectPool<SpawnObject> container)
        {
            presenter.SpawnObjectPoolUseCase.Load(key, container);
        }

        public static SpawnObject SpawnObject(this IMultipleSpawnerPresenter presenter, string key)
        {
            return presenter.SpawnObjectPoolUseCase.Spawn(key);
        }

        public static void KillObject(this IMultipleSpawnerPresenter presenter, SpawnObject container)
        {
            presenter.SpawnObjectPoolUseCase.Kill(container.ObjectPoolKey, container);
        }
    }
}