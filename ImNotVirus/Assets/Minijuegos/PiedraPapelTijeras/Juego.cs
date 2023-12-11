using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Juego : MonoBehaviour
{
    public TextMeshProUGUI textoResultado;
    public TextMeshProUGUI textoTitulo;
    public Button botonPiedraJugador;
    public Button botonPapelJugador;
    public Button botonTijerasJugador;
    public Button botonSalir;
    public RawImage piedraOponente;
    public RawImage papelOponente;
    public RawImage tijerasOponente;

    private bool juegoActivo;
    
    // Start is called before the first frame update
    void Start()
    {
        juegoActivo = true; // para que el jugador no le de varias veces al boton.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private byte Comprobacion(byte botonJugador, byte botonOponente)
    {
        // Perder 0, Ganar 1, Empate 2.
        // 1 Piedra, 2 Papel, 3 Tijeras.
        if (botonJugador == botonOponente)
        {
            return 2;
        }else if (botonJugador == 1 && botonOponente == 2)
        {
            return 0;
        } else if (botonJugador == 1 && botonOponente == 3)
        {
            return 1;
        } else if (botonJugador == 2 && botonOponente == 1)
        {
            return 1;
        } else if (botonJugador == 2 && botonOponente == 3)
        {
            return 0;
        } else if (botonJugador == 3 && botonOponente == 1)
        {
            return 0;
        } else if (botonJugador == 3 && botonOponente == 2)
        {
            return 1;
        }
            return 2;
    } // method

    private void MostrarImagenes(byte botonJugador, byte botonOponente)
    {
        switch(botonJugador)
        {
            case 1:
                botonPapelJugador.gameObject.SetActive(false);
                botonTijerasJugador.gameObject.SetActive(false);
                break;
            case 2:
                botonPiedraJugador.gameObject.SetActive(false);
                botonTijerasJugador.gameObject.SetActive(false);
                break;
            case 3:
                botonPiedraJugador.gameObject.SetActive(false);
                botonPapelJugador.gameObject.SetActive(false);
                break;
        } // switch

        switch(botonOponente)
        {
            case 1:
                piedraOponente.gameObject.SetActive(true);
                break;
            case 2:
                papelOponente.gameObject.SetActive(true);
                break;
            case 3:
                tijerasOponente.gameObject.SetActive(true);
                break;
        } // switch
    } // method

    public void BotonPulsado(int eleccion)
    {
        if (juegoActivo)
        {
            byte eleccionOponente = (byte)Random.Range(1, 4);
            Debug.Log("Jugador: " + eleccion + " Oponente: " + eleccionOponente);
            byte resultado = Comprobacion((byte)eleccion, eleccionOponente);

            switch (resultado)
            {
                case 0:
                    textoResultado.SetText("�Has Perdido!");
                    break;
                case 1:
                    textoResultado.SetText("�Has Ganado!");
                    break;
                case 2:
                    textoResultado.SetText("�Hab�is empatado!");
                    break;
            }

            MostrarImagenes((byte)eleccion, eleccionOponente);
            textoTitulo.gameObject.SetActive(false);
            textoResultado.gameObject.SetActive(true);
            botonSalir.gameObject.SetActive(true);
            juegoActivo = false;
        } // if
    } // method

    public void SalirJuego()
    {
        // Aqui se mete lo que haga falta para cambiar de escena.
        SceneManager.LoadScene("Nivel1");
    }

}
