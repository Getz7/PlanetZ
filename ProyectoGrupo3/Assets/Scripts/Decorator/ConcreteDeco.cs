using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteDeco : Decorator
{
    private int damagedeco;
    public ConcreteDeco(int amount)
    {
        damagedeco = amount;
    }
    public void ApplyDecorator(PlayerController player)
    {
        player.ApplyDamageDecorator(damagedeco, 10);
    }

    
}

public class SpeedBoostDecorator : Decorator
{
    private float speedBoostAmount;

    public SpeedBoostDecorator(float boostAmount)
    {
        speedBoostAmount = boostAmount;
    }

    public void ApplyDecorator(PlayerController player)
    {
        player.ApplySpeedDecorator(speedBoostAmount, 10); 
    }

  
}
public class jumpBoostDecorator : Decorator
{
    private float jumpBoostAmount;

    public jumpBoostDecorator(float boostAmount)
    {
        jumpBoostAmount= boostAmount;
    }

    public void ApplyDecorator(PlayerController player)
    {
        player.ApplyJumpDecorator(jumpBoostAmount, 10);
    }


}
