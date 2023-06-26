using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Producto concreto
[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemies/Centipede", order = 1)]
public class Centipede : ScriptableObject
{
    int hp = 5;
    int dmg = 3;
    string type = "Centipede";
    float speed = 1f;

    Sprite model;
}
