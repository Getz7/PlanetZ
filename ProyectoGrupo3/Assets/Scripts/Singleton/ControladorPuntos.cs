using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instancia;

    [SerializeField] private float cantidadPuntos;

    public float CantidadPuntos { get => cantidadPuntos ; set=> cantidadPuntos = value;}       

    private void Awake(){

        if (ControladorPuntos.Instancia == null)
        {
            ControladorPuntos.Instancia = this;
            DontDestroyOnLoad(this.gameObject);
            
        }else
        {
            Destroy(gameObject);
        }


    }

    public void SumarPuntos(float tPuntos){

        CantidadPuntos += tPuntos;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
