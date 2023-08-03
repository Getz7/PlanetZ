using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volador : Enemy
{
    public Vector3 PuntoInicial;

    [SerializeField] private float followSpeed = 20f;

    protected override void Update()
    {
        base.Update(); 

        
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }
    protected override void Awake()
    {
        base.Awake();

       
        PuntoInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
  

    public override void Attack()
    {
        
    }

    private void MoveTowardsPlayer()
    {
        
        Vector3 directionToPlayer = player.transform.position - transform.position;

        
        directionToPlayer.Normalize();

        
        Vector3 targetPosition = transform.position + directionToPlayer * followSpeed * Time.deltaTime;

        
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }

    public override void Move()
    {
       
    }

    public override void TakeDmg()
    {
        
    }
}
