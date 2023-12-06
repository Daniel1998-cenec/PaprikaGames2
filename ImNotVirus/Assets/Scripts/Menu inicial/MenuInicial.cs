using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    private ReiniciarCheckpoint reiniciar;
    void Start()
    {
        reiniciar = GameObject.Find("Control").GetComponent<ReiniciarCheckpoint>();
    }

    
    void Update()
    {
        
    }

    public void NuevaPartida()
    {
        reiniciar.ReiniciarCheckpoints();

        SceneManager.LoadScene("Nivel1");
    }

    public void Continuar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
