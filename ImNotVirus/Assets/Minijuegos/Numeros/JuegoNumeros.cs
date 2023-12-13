using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class JuegoMano : MonoBehaviour
{
    public TextMeshProUGUI textoJuego;
    public TextMeshProUGUI textoResultado;
    public TextMeshProUGUI textoFinal;
    public Button botonSalir;
    public int ultimoNumero;
    public int ultimoNumeroAux;
    public int aciertos = 0;

    public List<GameObject> manosObjetos = new List<GameObject>();
    public List<GameObject> botones = new List<GameObject>();

    void Start()
    {
        StartCoroutine(mostrarManos());
        Invoke("MostrarBotones",10);
        
    }

    IEnumerator mostrarManos()
    {
        int index = 0;
        foreach(GameObject mano in manosObjetos)
        {
            mano.SetActive(true);
            ultimoNumero = index;
            if (index > 0)
            {
                textoJuego.text = "Este es el número " + (index-1);
            }
            
            yield return new WaitForSecondsRealtime(2);
            mano.SetActive(false);
            index++;
        }
        generarMano();
    }

    public void pulsarBoton(int numero)
    {
        if (numero == ultimoNumero)
        {
            aciertos++;
            textoResultado.text = "¡Acertaste!";
        }
        else
        {
            textoResultado.text = "¡Fallaste! Era el " + ultimoNumero;
        }
        ultimoNumero = ultimoNumeroAux;
        if (aciertos < 3)
        {
            generarMano();
        }
        else
        {
            textoFinal.gameObject.SetActive(true);
            foreach (GameObject mano in manosObjetos)
            {
                mano.SetActive(false);
            }
            textoResultado.gameObject.SetActive(false);
            textoJuego.gameObject.SetActive(false);
            EsconderBotones();
            PlayerPrefs.SetInt("Numeros",2);
            botonSalir.gameObject.SetActive(true);
        }
    }

    void generarMano()
    {
        foreach(GameObject mano in manosObjetos)
        {
            mano.SetActive(false);
        }
        int numeroRandom = Random.Range(0, 6); //selecciona la mano que vamos a mostrar
        manosObjetos[numeroRandom].gameObject.SetActive(true);
        ultimoNumeroAux = numeroRandom;
        textoJuego.text = "¿Qué número es este?";
    }

    void MostrarBotones()
    {
        foreach (GameObject boton in botones)
            {
                boton.SetActive(true);
            }
    }

    void EsconderBotones()
    {
        foreach (GameObject boton in botones)
            {
                boton.SetActive(false);
            }
    }


    public void Salir()
    {
        SceneManager.LoadScene("Nivel1");
    }
}