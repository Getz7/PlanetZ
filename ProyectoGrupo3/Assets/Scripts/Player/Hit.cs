using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private bool isSpecial;
    protected virtual void Update()
    {
        if (isSpecial)
        {
            StartCoroutine(Autodestroy());
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDmg(FindObjectOfType<PlayerController>().GetDamage());
           
        }
        if (!isSpecial)
        {
            this.gameObject.SetActive(false);
        }
    }
    private IEnumerator Autodestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

}