using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // common propperties
   

    [SerializeField] private string _type;
    public Rigidbody2D rg2D;
    protected GameManager gm;
    public PlayerController player;
    public Animator anim;
    public Vector3 target;
    public bool facingRight;

    //Get
    public string Type => _type;

     

    public Enemy(int hp, int dmg, float speed)
    {
       
        
    }

    public Enemy()
    {

    }
    protected virtual void Start()
    {
        
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
            this.transform.localScale = new Vector3((float)-0.5, (float)0.5, (float)0.5);
            facingRight = false;

        }
        else
        {
            this.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);
            facingRight = true;
        }

    }

    public abstract void Move();
   

    public abstract void Attack();



    public abstract void TakeDmg();
    

    protected void Die()
    {

    }
   
    
}
