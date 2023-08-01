using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : Item
{
    public override void Accept(IItemVisitor visitor)
    {
        visitor.VisitSpeedItem(this);
    }
    public PlayerController GetPlayerController()
    {
        return FindObjectOfType<PlayerController>();
    }
}