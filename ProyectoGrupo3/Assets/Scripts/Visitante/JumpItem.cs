using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItem : Item
{
    public override void Accept(IItemVisitor visitor)
    {
        visitor.VisitJumpItem(this);
    }
    public PlayerController GetPlayerController()
    {
        return FindObjectOfType<PlayerController>();
    }
}