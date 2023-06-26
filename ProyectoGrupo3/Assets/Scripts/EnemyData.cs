using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName ="ScriptableObject/Enemies", order =1)]
public class EnemyData : ScriptableObject
{

    public string enemyType;
    public int hp;
    public int damage;
    public float speed;
    public Sprite enemyModel;
}
