using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialJumpCommand : ICommand
{
    private PlayerController _player;

    public SpecialJumpCommand(PlayerController player)
    {
        _player = player;
    }

    public void Execute()
    {
        _player.JumpSpecial();
    }

    public void Undo()
    {
        // Undo logic if needed
    }
}
