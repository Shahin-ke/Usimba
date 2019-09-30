using System;
using SH_SWAT.Usimba.EventOrientedModule.CQRS;
using UnityEngine;

namespace SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Messages
{
    public class SomeMessage : IEvent
    {
        public string Message { get; private set; }

        public SomeMessage(string message, GameObject entity, DateTime utcOccureTime)
        {
            Message = message;
            EventSender = entity;
            UtcOccurTime = utcOccureTime;
        }

        public GameObject EventSender { get; }
        public DateTime UtcOccurTime { get; }
    }
}