using System;
using UnityEngine;

namespace SH_SWAT.Usimba.EventOrientedModule.CQRS
{
    public interface IEvent : IMessage
    {
        GameObject EventSender { get; }
        DateTime UtcOccurTime { get; }
    }
}