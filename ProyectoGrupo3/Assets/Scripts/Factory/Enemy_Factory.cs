using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Enemy_Factory : MonoBehaviour, Abstract_Factory_Enemy
{
    //Lista para guardar los enemigos creados
    [SerializeField] private Enemy[] _Enemies;
    //Diccionario para mapear los enemigos en caso de crear nuevos enemigos
    private Dictionary<string, Enemy> _TypeToEnemy;

    private GameObject leftEdge, RightEdge;


    private void Awake()
    {

        _TypeToEnemy = new Dictionary<string, Enemy>();
        //HAcemos un recorrido en la lista de enemigos para guardarlos en el diccionario con su respectiva key:value
        foreach (var enemy in _Enemies)
        {
            _TypeToEnemy.Add(enemy.Type, enemy);
        }
    }


    public Enemy CreateEnemy(string enemyType, Vector2 position)
    {
        Enemy enemy;

        if (!_TypeToEnemy.TryGetValue(enemyType, out enemy))
        {
            throw new ArgumentException("Invalid enemy type: " + enemyType);
        }
        
       
        return Instantiate(enemy, position, Quaternion.identity);

    }

   

   
   
    
        

      

    
}
