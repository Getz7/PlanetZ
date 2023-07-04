using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

// Concrete Command

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
        _player.RegresaralSuelo();
    }

    public void Undo()
    {
       
    }
}

