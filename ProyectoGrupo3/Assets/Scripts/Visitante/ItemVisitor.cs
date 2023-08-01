using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVisitor : IItemVisitor
{
    public void VisitHealthItem(HealthItem item)
    {
       
        PlayerController playerController = item.GetPlayerController(); 

        
        playerController.DecreaseHealth(1);

        
    
    }

    public void VisitJumpItem(JumpItem item)
    {
       
        PlayerController playerController = item.GetPlayerController(); 

     
        playerController.IncreaseJumpForceTemporarily(10, 5f);

      
        
    }

    public void VisitSpeedItem(SpeedItem item)
    {
       
        PlayerController playerController = item.GetPlayerController();

       
        playerController.IncreaseRunSpeedTemporarily(10, 5f);

       
       
    }

}
