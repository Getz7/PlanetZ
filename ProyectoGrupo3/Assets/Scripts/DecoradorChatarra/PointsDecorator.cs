using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsDecorator : IDecorator
{
    private int _pointsToAdd;

    public PointsDecorator(int pointsToAdd)
    {
        _pointsToAdd = pointsToAdd;
    }

    public void ApplyDecorator(PlayerController player)
    {
        player.ApplyPoints(_pointsToAdd);
       
    }
}
