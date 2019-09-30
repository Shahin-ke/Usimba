using UnityEngine;

namespace SH_SWAT.Usimba.EventOrientedModule.CQRS
{
    public interface ICommand : IMessage
    {
        GameObject Entity { get; }
    }
}