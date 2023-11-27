using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BotonScript : MonoBehaviour
{
    [SerializeField] private ControlScript control;
    private Image imgActual;
    void Start()
    {
        imgActual = GetComponent<UnityEngine.UI.Image>();       
    }

    void Update()
    {
        
    }

    public void CambiarImagenPlayer()
    {
        if(!control.fin)
        {
            Debug.Log("Se intenta pulsar un boton");
            
            if(imgActual.sprite == control.imagenes[0])
            {
                imgActual.sprite = control.imagenes[1];
                control.turnoJugador = false;
            }
            control.ComprobarCasillas(control.imagenes[1]);
        }
    }

}
