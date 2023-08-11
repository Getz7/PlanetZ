using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaUI : MonoBehaviour
{

    //public TypeOfSound sonido = TypeOfSound.Boton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changescene(string nombreEscena)
    {


       
        //Sound_Handler.Instance.playsound((int)sonido);
        SceneManager.LoadScene(nombreEscena);
    }
    public void CambiarUltimaEscenaJugada()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("escenaActual", "Portada"));
    }
    public void ReseteoTiempo()
    {
        PlayerPrefs.SetFloat("TiempoEscena1", 0);
        PlayerPrefs.SetFloat("TiempoEscena2", 0);
        PlayerPrefs.SetFloat("TiempoEscena3", 0);

    }
    public void SalirJuego()
    {
        Application.Quit();
    }
}
