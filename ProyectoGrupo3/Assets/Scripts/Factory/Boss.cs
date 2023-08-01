using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy

{

    [SerializeField] private float timeToChangeDirection = 0f;
    [SerializeField] private float timeToSpawnEenemy = 0f;
    [SerializeField] public float speed = 2f;
    [SerializeField] private bool movingRight = false;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float spawnTimer = 0f;
    [SerializeField] private Enemy_Factory _enemyFac;
    private int moveDirection = 1; // -1 for left, 1 for right
    private SpriteRenderer SR;


    void Start()
    {
        moveDirection = movingRight ? 1 : -1;
        SR = GetComponent<SpriteRenderer>();
        UpdateSpriteOrientation();
        _enemyFac = FindObjectOfType<Enemy_Factory>();
    }

    public override void Move()
    {
        anim.SetBool("move", true);

        transform.Translate(moveDirection * Vector2.right * speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= timeToChangeDirection)
        {
            moveDirection *= -1;
            UpdateSpriteOrientation();

            timer = 0f;
        }
    }

    public override void TakeDmg()
    {
        
    }

    // Start is called before the first frame update


    // Update is called once per frame
    private void Update()
    {
        Move();
        SpawnEnemy();
    }

    public void UpdateSpriteOrientation()
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
        throw new System.NotImplementedException();
    }

    public void SpawnEnemy()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= timeToSpawnEenemy)
        {
            _enemyFac.CreateEnemy("Centipede", new Vector2(90, -101));
            spawnTimer = 0f;
        }
    }
}
