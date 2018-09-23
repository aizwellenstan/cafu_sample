using System.Collections.Generic;
using Monry.CAFUSample.Domain.Structure;
using Monry.CAFUSample.Domain.UseCase;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class MolePresenter : IMolePresenter, IMoleListManager
    {
        [Inject] private IFactory<int, IMole, IMoleView> MoleViewFactory { get; }

        private List<IMoleView> MoleViewList { get; } = new List<IMoleView>();

        public void Instantiate(int index, IMole mole)
        {
            MoleViewList.Add(MoleViewFactory.Create(index, mole));
        }

        public Transform GetMoleTransform(int index)
        {
            return MoleViewList[index].GetTransform();
        }
    }
}