using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBySpikes : MonoBehaviour
{
    //public TimeController contador;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    private string nombreDato;
    private bool First;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null && playerController.IsShieldActive())
            {
                // The player has an active shield, so they survive the spikes
                return;
            }

            StartCoroutine(SecuenciaMorir());
        }
    }

    IEnumerator SecuenciaMorir()
    {
        //Pausar tiempo
        Time.timeScale = 1;
        //Esperar 1 segundo
        yield return new WaitForSeconds(0.1f);
        //Reaunudar el tiempo
        Time.timeScale = 1;
        //cambiar escena
        //PlayerPrefs.SetFloat(nombreDato, contador.restante);
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.StartCoroutine(playerController.ShieldVulnerabilityPeriod());
        }
        SceneManager.LoadScene("Perdida");
    }
    private void Update()
    {
        if (player.gameObject.activeInHierarchy == false && First)
        {
            StartCoroutine(SecuenciaMorir());
        }
    }
}
