using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoostDecorator : IDecorator
{
  
   
   
        private int damagedeco;
        public DamageBoostDecorator(int amount)
        {
            damagedeco = amount;
        }
        public void ApplyDecorator(PlayerController player)
        {
            player.ApplyDamageDecorator(damagedeco, 10);
        }


}


