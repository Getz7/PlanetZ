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
       
        if (playercontrol._HealthPoints < numeroMinimo)
        {

       
            corazon1.enabled = false;
        }
        else
        {
            corazon1.enabled = true;
        }



        
    }




}
