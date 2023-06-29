using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Command Interface

public interface ICommand
{
    void Execute();
    void Undo();
}

