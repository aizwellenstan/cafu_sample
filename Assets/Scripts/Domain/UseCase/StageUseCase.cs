using CAFU.Core;
using Monry.CAFUSample.Entity;
using Zenject;

namespace Monry.CAFUSample.UseCase
{
    public class StageUseCase : IUseCase
    {
        [Inject] private IGameStateEntity GameStateModel { get; }

        public void Attacked()
        {
            GameStateModel.Score.Value++;
        }
    }
}