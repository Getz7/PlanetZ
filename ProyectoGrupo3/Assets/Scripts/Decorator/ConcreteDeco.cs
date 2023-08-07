using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteDeco : Decorator
{
    private int healthDeco;
    public ConcreteDeco(int amount)
    {
        healthDeco = amount;
    }
    public void ApplyDecorator(PlayerController player)
    {
        player.ApplyHealthDecorator(healthDeco);
    }

    public FlyWeight getItem()
    {
        return new FlyWeight(null, null, healthDeco);
    }
}

public class SpeedBoostDecorator : Decorator
{
    private float speedBoostAmount;

    public SpeedBoostDecorator(float amount)
    {
        speedBoostAmount = amount;
    }

    public void ApplyDecorator(PlayerController player)
    {
        player.IncreaseRunSpeedTemporarily(speedBoostAmount, 20f); 
    }

    public FlyWeight getItem()
    {
        return new FlyWeight(null, null, (int)speedBoostAmount);
    }
}
