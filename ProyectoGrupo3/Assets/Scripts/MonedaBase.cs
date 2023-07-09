
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MonedaBase : MonoBehaviour

{

    

[SerializeField] private Monedas originalObject;
[SerializeField] float  cantidad;






    public void ClonarObjetos(float cantidad1)
    {

               
        List<Monedas> clones = new List<Monedas>();
        for (int i = 0; i < cantidad1; i++)
        {

            
            Monedas clone = (Monedas)originalObject.Clone();
            clones.Add(clone);
              
            
        }
    }

    

    void Start()
    {
        
        ClonarObjetos(cantidad);

              
        

    }
 
    void Update()
    {
        
      
    }
    
    
}
