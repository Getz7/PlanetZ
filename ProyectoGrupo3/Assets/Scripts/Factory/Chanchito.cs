using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chanchito : Enemy
{

    [SerializeField] private float fallDelay;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float resetDelay;
    [SerializeField] private float resetSpeed;
    [SerializeField] private LayerMask groundLayer;
    private Vector2 initialPosition;

    private Rigidbody2D RB;
    private SpriteRenderer SR;
    private bool isFalling = false;

    private Coroutine resetCoroutine; // To manage the reset coroutine
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {

    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(resetDelay);

        while (transform.position.y < initialPosition.y)
        {
            Vector2 newPos = transform.position + Vector3.up * (resetSpeed * Time.deltaTime);
            transform.position = newPos;
            yield return null;
        }

        transform.position = initialPosition; // Resets enemy position
        RB.gravityScale = 0f; // Disable gravity 
    }




    void startFalling()
    {
        isFalling = true;
        RB.gravityScale = 1f; // Enable gravity for falling effect
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("startFalling", fallDelay);
        }
    }

    public override void TakeDmg(float dmgAmount)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    protected override void Start()
    {

        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        initialPosition = transform.position; // Store the initial position
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Awake();
        if (isFalling)
        {
            Vector2 fallVelocity = new Vector2(0f, -fallSpeed);
            RB.velocity = fallVelocity;


            // Check for collision with ground
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundLayer);
            if (hit.collider != null)
            {
                isFalling = false;
                RB.velocity = Vector2.zero; // Stop the boulder's movement

                if (resetCoroutine != null)
                {
                    StopCoroutine(resetCoroutine);// Stop any ongoing reset coroutine
                }
                resetCoroutine = StartCoroutine(ResetPosition());
            }
        }
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }
}
