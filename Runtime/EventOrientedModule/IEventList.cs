using SH_SWAT.Usimba.EventOrientedModule.CQRS;

namespace SH_SWAT.Usimba.EventOrientedModule
{
    public interface IEventList
    {
        void ApplyChange(IEvent evt, bool isNew);
        void SetOwner(object obj);
    }
}