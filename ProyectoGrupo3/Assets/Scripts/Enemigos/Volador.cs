using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volador : Enemy
{
    public override void Attack()
    {

    }

    public override void Move()
    {

    }

    public override void TakeDmg()
    {

    }

    public int damage = 1;
    public float distanciaAtaque = 4f;
    public Vector3 PuntoInicial;
    public float velocidadMovimiento = 5f;
    protected override void Start()
    {
        base.Start();
        PuntoInicial = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
    protected override void Update()
    {
        base.Update();
        //enemyHP > 0

        //Player no esta en distancia de ataque 
        float distanciaActual = Vector3.Distance(this.transform.position, player.gameObject.transform.position);
        if (distanciaActual > distanciaAtaque)
        {
            //No va a atacar y se va a devolver al punto de origen
            target = new Vector3(
                PuntoInicial.x - this.transform.position.x,//calculo direccion en x 
                PuntoInicial.y - this.transform.position.y,//calculo direccion en y
                PuntoInicial.z - this.transform.position.z//calculo direccion en z
                );
            //aplicar velocidad al cuerpo para que se devuelva al punto inical
            rg2D.velocity = target.normalized * velocidadMovimiento;
            //identificar a donde nos dirigimos 
          anim.SetBool("Vejugador", false);
        }
        //Player esta en distancia de ataque
        else
        {
            //Enemigo persigue al jugador 
            // en que direccion se encuentra el jugador
            target = new Vector3(
                player.transform.position.x - this.transform.position.x,//calculo direccion en x 
                player.transform.position.y - this.transform.position.y,//calculo direccion en y
                player.transform.position.z - this.transform.position.z//calculo direccion en z
                );

            //aplicar velocidad al cuerpo rigido para que se mueva en direccion al jugador 
            rg2D.velocity = target.normalized * velocidadMovimiento;
            
            anim.SetBool("Vejugador", true);
        }

    }
}
