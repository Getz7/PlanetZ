using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Invoker
public class Invoker
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command?.Execute();
    }

    public void UndoCommand()
    {
        _command?.Undo();
    }
}
