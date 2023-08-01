using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    public override void Accept(IItemVisitor visitor)
    {
        visitor.VisitHealthItem(this);
    }
    public PlayerController GetPlayerController()
    {
        return FindObjectOfType<PlayerController>();
    }
}