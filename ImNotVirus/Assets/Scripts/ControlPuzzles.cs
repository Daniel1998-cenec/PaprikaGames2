using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class ControlPuzzles : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    public GameObject puerta;
    [SerializeField] InteractScript interact;
    void Start()
    {

    }

    void Update()
    {
        if(PlayerPrefs.GetInt("TresEnRaya")==2 && PlayerPrefs.GetInt("PiedraPapelTijeras")==2)
        {
            interact.Unlock(GameObject.Find("Acertijos"));
            interact.Unlock(GameObject.Find("Numeros"));
            player.checkPoint();
            puerta.gameObject.SetActive(false);
            Debug.Log("Se ha abierto una puerta.");
        }
    }

}
