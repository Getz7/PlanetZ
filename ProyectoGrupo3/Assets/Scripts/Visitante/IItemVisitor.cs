using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemVisitor
{
    void VisitHealthItem(HealthItem item);
    void VisitJumpItem(JumpItem item);
    void VisitSpeedItem(SpeedItem item);
}