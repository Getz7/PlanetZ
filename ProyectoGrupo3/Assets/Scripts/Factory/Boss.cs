using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : Enemy

{

    
    [SerializeField] private float timeToSpawnEenemy = 0f;
    
    [SerializeField] private Enemy_Factory _enemyFac;
    [SerializeField] private float visionRange = 10f; // The range at which the player should trigger spawning
    [SerializeField] private GameObject key;
    private Vector2 initialPosition;
    private int moveDirection = 1; // -1 for left, 1 for right
    private SpriteRenderer SR;
    public Transform playerPos; // Reference to the player's transform
    private int maxEnemiesToSpawn = 5;
    private int enemiesSpawned = 0; // Counter for spawned enemies
    private float spawnTimer = 0f;
    private float timer = 0f;
    private bool hasDroppedKey = false;
    private BoxCollider2D box;





    protected override void Start()
    {
        moveDirection = movingRight ? 1 : -1;
        SR = GetComponent<SpriteRenderer>();
        UpdateSpriteOrientation();
        _enemyFac = FindObjectOfType<Enemy_Factory>();
        initialPosition = transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        box = GetComponent<BoxCollider2D>();

    }

    public override void Move()
    {
        anim.SetBool("move", true);

        transform.Translate(moveDirection * Vector2.right * MoveSpeed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= timeToChangeDirection)
        {
            moveDirection *= -1;
            UpdateSpriteOrientation();

            timer = 0f;
        }
    }

    public override void TakeDmg(float dmgAmount)
    {
        Health -= dmgAmount;
        anim.SetTrigger("hurt");
        if (Health <= 0 && !hasDroppedKey)
        {
            hasDroppedKey = true;
            FindObjectOfType<GameManager>().EnemigoDestruido();
            Invoke("Die", 0.1f);
            if (key != null) Instantiate(key, this.transform.position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    protected override void Update()
    {
        
        
        
        Move();
       

        float distanceToPlayer = Vector2.Distance(playerPos.position, transform.position);

        if(distanceToPlayer <= visionRange && enemiesSpawned < maxEnemiesToSpawn)
        {
            SpawnEnemy();
        }
        speedUp();
    }

    

    private void UpdateSpriteOrientation()
    {
        // Flip the sprite along the X-axis if moving left
        if (moveDirection < 0)
        {
            SR.flipX = false;
        }
        else
        {
            SR.flipX = true; 
        }
    }
    public override void Attack()
    {
       
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

    private void SpawnEnemy()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= timeToSpawnEenemy)
        {
            
                _enemyFac.CreateEnemy("Centipede", new Vector2(initialPosition.x - Random.Range(1, 20), (initialPosition.y - 1.4f)));
                spawnTimer = 0f;
            enemiesSpawned++;
           
            
        }
    }

    public override void Die()
    {
        anim.SetTrigger("die");
        // this.gameObject.SetActive(false);
        GetComponent<Boss>().enabled = false;
        box.enabled = false;
    }

    public float GetDamage()
    {
        return Damage;
    }
    public void speedUp()
    {
        if (Health < 8)
        {
            MoveSpeed = 4;
        }

    }
}
