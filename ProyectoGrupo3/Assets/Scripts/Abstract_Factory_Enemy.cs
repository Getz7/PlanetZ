using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Abstract_Factory_Enemy 
{
    public Enemy CreateEnemy(string enemyType, Vector2 pos);
}
