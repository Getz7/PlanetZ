using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// JumpCommand.cs

public class JumpCommand : ICommand
{
    private PlayerController _player;

    public JumpCommand(PlayerController player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.Jump();
    }

    public void Undo()
    {
        // Undo logic if needed
    }
}

