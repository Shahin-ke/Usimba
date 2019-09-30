namespace SH_SWAT.Usimba.EventOrientedModule.CQRS
{
    public interface ICommandHandler<in TCommand> : IMessageHandler<TCommand>
        where TCommand : ICommand
    {
        new void Handle(TCommand cmd);
    }
}