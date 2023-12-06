using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarCheckpoint : MonoBehaviour
{   
    void Start()
    {
        ReiniciarCheckpoints();
    }

    void Update()
    {
        
    }

    public void ReiniciarCheckpoints()
    {
        /*
        0 - Sin hacer, bloqueado
        1- Sin hacer, desbloqueado
        2 - Hecho
        */

        PlayerPrefs.SetFloat("xPos", 0.0f);
        PlayerPrefs.SetFloat("yPos", 0.0f);
        PlayerPrefs.SetInt("Comienzo", 0);
        PlayerPrefs.SetInt("Palanca", 1);
        PlayerPrefs.SetInt("Electricidad1", 0);
        PlayerPrefs.SetInt("Refranes", 0);
        PlayerPrefs.SetInt("Electricidad2", 0);
        PlayerPrefs.SetInt("TresEnRaya", 0);
        PlayerPrefs.SetInt("PiedraPapelTijeras", 0);
        PlayerPrefs.SetInt("Acertijos", 0);
        PlayerPrefs.SetInt("Numeros", 0);
    }
}
