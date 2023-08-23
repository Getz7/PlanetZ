using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Torreta : Enemy
{
    public float distance;
    public float shootInterval;
    public float wakerange;
    public float flechaSpeed = 100;
    public float flechaTimer;
    public GameObject flecha;
    public UnityEngine.Transform shootPointRight;
    private BoxCollider2D box;
    public override void Attack()
    {

    }
    protected override void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    protected override void Awake()
    {
        base.Awake();

    }
    protected override void Update()
    {
        base.Update();
        target = new Vector3(
                      player.gameObject.transform.position.x - this.transform.position.x,//calculo direccion en x 
                      0f,//calculo direccion en y
                      0f//calculo direccion en z
                      );
        anim.SetFloat("Speed", Mathf.Abs(rg2D.velocity.magnitude));
    }
    private void RangeCheck()
    {

        distance = Vector3.Distance(transform.position, target);


    }
    public void Attack(bool attackingRight)
    {
        flechaTimer += Time.deltaTime;
        if (flechaTimer >= shootInterval)
        {
            Vector2 direction = shootPointRight.transform.position - transform.position;
            direction.Normalize();
            if (attackingRight)
            {

                GameObject flechaClone;
                flechaClone = Instantiate(flecha, shootPointRight.transform.position, Quaternion.identity);
                flechaClone.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * flechaSpeed, rg2D.velocity.y);
                flechaClone.transform.localScale = new Vector3(1, 1, 1);

                flechaTimer = 0;
                anim.SetBool("Attacking", true);
            }
            else //(attackingRight)
            {
                GameObject flechaClone;
                flechaClone = Instantiate(flecha, shootPointRight.transform.position, Quaternion.identity);
                flechaClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * flechaSpeed, rg2D.velocity.y);
                flechaClone.transform.localScale = new Vector3(-1, 1, 1);
                flechaTimer = 0;
                anim.SetBool("Attacking", true);
            }
            
        }
        
    }


    public override void Move()
    {

    }

    public override void TakeDmg(float dmgAmount)
    {
        Health -= dmgAmount;
        anim.SetTrigger("hurt");
        if (Health <= 0)
        {
            FindObjectOfType<GameManager>().EnemigoDestruido();
            Invoke("Die", 0.1f);
        }
    }

    public override void Die()
    {
        anim.SetTrigger("die");
        // this.gameObject.SetActive(false);
        GetComponent<Torreta>().enabled = false;
        
        box.enabled = false;
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player != null)
            {

                player.Hurt((int)GetDamage());
            }
        }

    }
    public float GetDamage()
    {
        return Damage;
    }
}
