using System;

namespace SH_SWAT.Usimba.EventOrientedModule.CQRS
{
    public interface IActionExecutor
    {
        bool CanExecuteForParameters(params object[] parameters);
        void Execute(params object[] parameters);

        Type ParameterType(int index);
    }
}