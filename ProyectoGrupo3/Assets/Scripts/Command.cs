using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ICommand.cs

public interface ICommand
{
    void Execute();
    void Undo();
}

