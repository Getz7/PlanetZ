using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public PlayerController player;
    public int enemyDamage = 1;
    [SerializeField] public float _EHealthPoints, MaxHealth = 8f;
    protected GameManager gm;
    public float distanciaMinima = 5f;
    public Vector3 target;
    public float velocidadMovimiento = 5f;
    public Rigidbody2D rg2D;
    public bool facingRight;
    public Animator anim;
    public int stateAnim;


    protected virtual void Start()
    {
        _EHealthPoints = MaxHealth;
    }
    protected virtual void Awake()
    {
        rg2D = GetComponent<Rigidbody2D>();
        if (FindObjectOfType<PlayerController>() != null)
        {
            player = FindObjectOfType<PlayerController>();
        }
        if (FindObjectOfType<GameManager>() != null)
        {
            gm = FindObjectOfType<GameManager>();
        }

        if (TryGetComponent(out Animator animator))
        {
            anim = animator;
        }
    }
    protected virtual void Update()
    {
        if (player.transform.position.x < this.transform.position.x)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;

        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

    }

    public virtual void EnemyHurt(float damageAmount)
    {
        _EHealthPoints -= damageAmount;
        if (_EHealthPoints <= 0)
        {
            Debug.Log("Enemigo Destruido");
            FindObjectOfType<GameManager>().EnemigoDestruido();
            //gm.EnemigoDestruido()
        }
    }
    public void DesactivarObjeto()
    {
        rg2D.bodyType = RigidbodyType2D.Static;
        try
        {
            anim.SetTrigger("Death");
        }
        catch (Exception e)
        {
            Debug.Log("El elemento que intenta animar no tiene animacion death");
        }
    }
    public void Desactivar()
    {
        this.gameObject.SetActive(false);
    }
    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player != null)
            {
                player.Hurt(enemyDamage);
            }
        }

    }

}