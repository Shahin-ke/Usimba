//using SH_SWAT.Usimba.EventOrientedModule.CQRS;
//using SH_SWAT.Usimba.EventOrientedModule.Contexts;
//using UnityEngine;
//using Zenject;

//namespace SH_SWAT.Usimba.EventOrientedModule
//{
//    public class EventOrientedMonoBehaviour : MonoBehaviour
//    {
//        //public string Id => transform.GetGameObjectPath();
//        public GameObject Id => transform.gameObject;

//        private IEventList _eventList;
//        private GameContext _gameContext;

//        [Inject]
//        //public void Ctor(GameContext context)
//        public void Ctor(IMessageBus messageBus)
//        {
//            //_gameContext = context;
//            _eventList = new EventList(messageBus, this);
//        }

//        protected void ApplyChange(IEvent evt)
//        {
//            ApplyChange(evt, true);
//        }

//        private void ApplyChange(IEvent evt, bool isNew)
//        {
//            _eventList.ApplyChange(evt, isNew);
//        }
//}
//}
