using System;
using System.Collections.Generic;
using System.Linq;
using CAFU.Scene.Application;
using CAFU.Scene.Presentation.Presenter;
using CAFU.Zenject.Utility;
using Modules.Scripts.Utility;
using Monry.CAFUSample.Application.Enumerate;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Presentation.View.System
{
    public class Controller : MonoBehaviour,
        IInitializable,
        IInstancePublisher,
        ISceneLoadRequestable,
        ISystemController
    {
        [Inject] IMessagePublisher IInstancePublisher.MessagePublisher { get; }

        [SerializeField] private List<SceneName> initialSceneNameList;

        public IEnumerable<string> InitialSceneNameList
        {
            get { return initialSceneNameList.Select(x => x.ToString()); }
            set { initialSceneNameList = value.Select(SceneNameUtility.Parse<SceneName>).ToList(); }
        }

        private ISubject<string> RequestLoadSubject { get; } = new Subject<string>();

        void IInitializable.Initialize()
        {
            // インスタンス生成を通知
            //   CAFU Scene に対してインスタンスを通知して、Load/Unload のリクエストを処理可能にする
            this.Publish();

            InitialSceneNameList.ToObservable().Subscribe(RequestLoadSubject);
        }

        public IObservable<string> RequestLoadAsObservable()
        {
            return RequestLoadSubject;
        }
    }
}