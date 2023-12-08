using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicioMinijuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotonContinuar(string Refranes)
    {
        SceneManager.LoadScene("Refranes");
        Debug.Log("le has dado a continuar");
    }

    public void BotonContinuarAcertijo(string Refranes)
    {
        SceneManager.LoadScene("Acertijos");
        Debug.Log("le has dado a continuar");
    }

}
