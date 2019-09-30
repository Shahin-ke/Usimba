using System;
using SH_SWAT.Usimba.EventOrientedModule.CQRS;
using UnityEngine;

namespace SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Messages
{
    public class SomeOtherMessage : IEvent
    {
        private string _orginalMessage;

        public string Message
        {
            get
            {
                return _orginalMessage.ToUpper();
            }
        }

        public SomeOtherMessage(string message, GameObject entity, DateTime utcOccureTime)
        {
            _orginalMessage = message;
            EventSender = entity;
            UtcOccurTime = utcOccureTime;
        }

        public GameObject EventSender { get; }
        public DateTime UtcOccurTime { get; }
    }
}