using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBoostDecorator : IDecorator
{

    private float jumpBoostAmount;

    public jumpBoostDecorator(float boostAmount)
    {
        jumpBoostAmount = boostAmount;
    }

    public void ApplyDecorator(PlayerController player)
    {
        player.ApplyJumpDecorator(jumpBoostAmount, 10);

    }



}
