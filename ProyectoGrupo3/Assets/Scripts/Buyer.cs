using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyer : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Ejecutar el código que deseas cuando se hace clic en el objeto
        Debug.Log("Objeto clickeado: " + gameObject.name);
    }
}
