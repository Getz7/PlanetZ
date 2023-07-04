using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

   
    public PlayerController player;

    protected GameManager gm;
    [SerializeField] public float _EHealthPoints;
    private float currentHP;
    private Animator anim;
    private bool dead;
    // Start is called before the first frame update
    private void Awake()
    {
     
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
    public virtual void EnemyHurt(float damageAmount)
    {
        _EHealthPoints -= damageAmount;
        if (_EHealthPoints <= 0)
        {
            Debug.Log("Enemigo Destruido");
            FindObjectOfType<GameManager>().EnemigoDestruido();

            Invoke("Desactivar", 0.1f);


        }
    }
    public void Desactivar()
    {
        this.gameObject.SetActive(false);
    }
}
