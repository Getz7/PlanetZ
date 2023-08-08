using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemies", order = 1)]
public class NewEnemy : ScriptableObject
{
    //Lista para guardar los enemigos creados
    [SerializeField] private Enemy[] _Enemies;
    //Diccionario para mapear los enemigos en caso de crear nuevos enemigos
    private Dictionary<string, Enemy> _TypeToEnemy;


    private void Awake()
    {

        _TypeToEnemy = new Dictionary<string, Enemy>();
        //HAcemos un recorrido en la lista de enemigos para guardarlos en el diccionario con su respectiva key:value
        foreach (var enemy in _Enemies)
        {
            _TypeToEnemy.Add(enemy.Type, enemy);
        }
    }


    public Enemy GetEnemyPrefabByType(string enemyType)
    {
        Enemy enemy;

        if (!_TypeToEnemy.TryGetValue(enemyType, out enemy))
        {
            throw new ArgumentException("Invalid enemy type: " + enemyType);
        }
        return Instantiate(enemy);
    }
}
