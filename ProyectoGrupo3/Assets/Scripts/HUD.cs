using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PlayerController playercontrol;
    public Image corazon1;
    public int numeroMinimo = 1;
	


  

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log("El jugador  tiene  " + playercontrol._HealthPoints);
        if (playercontrol._HealthPoints < numeroMinimo)
        {

            Debug.Log("Se ha apagado un  " + this.gameObject.name);   
            corazon1.enabled = false;
        }
        else
        {
            corazon1.enabled = true;
        }



        
    }




}
