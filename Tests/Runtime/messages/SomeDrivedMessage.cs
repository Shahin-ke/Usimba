using System;
using UnityEngine;

namespace SH_SWAT.Usimba.UnitTests.Editor.MessageBus.UniRxExtension.Messages
{
    public class SomeDrivedMessage : SomeMessage
    {
        public SomeDrivedMessage(string message, GameObject entity, DateTime utcOccureTime)
            : base("Drived Type, " + message, entity, utcOccureTime)
        {
        }
    }
}