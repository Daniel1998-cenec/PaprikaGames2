using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
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
        PlayerPrefs.SetFloat("xPos", 0.0f);
        PlayerPrefs.SetFloat("yPos", 0.0f);
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
