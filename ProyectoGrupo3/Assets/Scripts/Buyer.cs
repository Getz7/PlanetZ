using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyer : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Ejecutar el c�digo que deseas cuando se hace clic en el objeto
        Debug.Log("Objeto clickeado: " + gameObject.name);
    }
  
}
