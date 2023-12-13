using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class ControlPuzzles : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    public GameObject puertaInicio;
    bool puertaInicioDesbloqueada = false;
    public GameObject puerta1;
    bool puerta1Desbloqueada = false;
    public GameObject puerta2;
    bool puerta2Desbloqueada = false;
    public GameObject puertaFinal;
    bool puertaFinalDesbloqueada = false;
    [SerializeField] InteractScript interact;
    void Start()
    {

    }

    void Update()
    {

        if(PlayerPrefs.GetInt("Palanca")==2 && puertaInicioDesbloqueada==false)
        {
            interact.Unlock(GameObject.Find("Electricidad1"));
            player.checkPoint();
            puertaInicio.gameObject.SetActive(false);
            Debug.Log("Se ha abierto una puerta.");
            puertaInicioDesbloqueada = true;
        }
        
        if(PlayerPrefs.GetInt("Electricidad1")==2 && PlayerPrefs.GetInt("Refranes")==2 && puerta1Desbloqueada==false)
        {
            interact.Unlock(GameObject.Find("Acertijos"));
            interact.Unlock(GameObject.Find("Numeros"));
            player.checkPoint();
            puerta1.gameObject.SetActive(false);
            Debug.Log("Se ha abierto una puerta.");
            puerta1Desbloqueada = true;
        }

        if(PlayerPrefs.GetInt("TresEnRaya")==2 && PlayerPrefs.GetInt("PiedraPapelTijeras")==2 && puerta2Desbloqueada==false)
        {
            interact.Unlock(GameObject.Find("Acertijos"));
            interact.Unlock(GameObject.Find("Numeros"));
            player.checkPoint();
            puerta1.gameObject.SetActive(false);
            Debug.Log("Se ha abierto una puerta.");
            puerta2Desbloqueada = true;
        }

        if(PlayerPrefs.GetInt("Acertijos")==2 && PlayerPrefs.GetInt("Numeros")==2 && puertaFinalDesbloqueada==false)
        {
            interact.Unlock(GameObject.Find("PuertaFinal"));
            player.checkPoint();
            puertaFinal.gameObject.SetActive(false);
            Debug.Log("Se ha abierto la puerta final.");
            puertaFinalDesbloqueada = true;
        }
    }

}
