//using Assets.IOC;
//using Assets.Scripts.CQRS;
//using UnityEngine;

//namespace Assets.Scripts.Contexts
//{
//    public class MonoGameContextAdapter : MonoBehaviour
//    {
//        public Zenject.DiContainer ZenjectContainer;
//        public Zenject.SceneContext SceneContext;

//        private GameContext _gameContext;

//        public void Awake()
//        {
//            ZenjectContainer = SceneContext.Container;
//            var messageBus = ZenjectContainer.Resolve<IMessageBus>();
//            _gameContext = new GameContext(new ZenjectServiceLocatorAdapter(ZenjectContainer), messageBus);
//        }
//    }
//}