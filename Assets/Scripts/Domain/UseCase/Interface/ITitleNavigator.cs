using System;
using UniRx;
using IPresenter = CAFU.Core.IPresenter;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface ITitleNavigator : IPresenter
    {
        IObservable<Unit> OnNavigateToGameAsObservable();
        IObservable<Unit> OnNavigateToRankingAsObservable();
    }
}