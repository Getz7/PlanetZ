using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    private float _Puntos;
    private TextMeshProUGUI  _TexMesh;
  

    // Start is called before the first frame update
    void Start()
    {

        _TexMesh = GetComponent<TextMeshProUGUI>();
        this.ActualizarPuntos(ControladorPuntos.Instancia.CantidadPuntos);
    }

    // Update is called once per frame
    void Update()
    {
        
         _TexMesh.text = "Puntos: " + _Puntos.ToString ("0");

    }


    public void ActualizarPuntos (float tPuntaje) 
    {
        _Puntos = tPuntaje;
                

    }
}
