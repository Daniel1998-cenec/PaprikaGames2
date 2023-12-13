using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlAcertijos : MonoBehaviour
{
    public TextMeshProUGUI acertijoText;
    public TextMeshProUGUI fraseFinalDelJuego;
    public TMP_InputField respuestaInput;
    public Button botonReinicio;
    public Button botonContinuar;
    public Button botonSalir;
    public TextMeshProUGUI textContador;
    private int aciertos;

    private List<string> acertijos = new List<string>
    {
        "Por un caminito, va caminando un bicho. El nombre del bicho ya te lo he dicho",
        "Húmedo por dentro, con pelos por fuera. Comienza por la C. ¿De qué se trata?",
        "Lo levanto cuando estoy contento, pero es más pequeño que el resto. ¿Qué es?",
        "Tiene famosa memoria, gran tamaño y dura piel y la nariz más grandota, que en el mundo pueda haber",
        "En rincones y entre ramas mis redes voy construyendo, para que moscas incautas, en ellas vayan cayendo",
        "Orejas largas, rabo cortito, corro y salto muy ligerito",
        "Me llegan las cartas y no sé leer y, aunque me las trago, no mancho el papel. ¿Qué es?",
        "Es pequeña como una pera, pero alumbra la casa entera. ¿Qué es?",
        "Tengo teclas, pero no puedo tocar música. Tengo letras, pero no puedo hablar. ¿Qué soy?",
        "¿Quién allí en lo alto en las ramas mora y allí esconde, avara, todo lo que roba?"
    };

    private List<string> respuestas = new List<string>
    {
        "vaca","coco","pulgar","elefante","araña","conejo","buzon","bombilla","teclado","ardilla"
    };

    void Start()
    {
        aciertos = PlayerPrefs.GetInt("aciertos");

        if (aciertos == 3)
        {
            FinDelJuego();
        }

        MostrarAcertijoRandom();

        // Suscribir la funci�n ComprobarRespuesta a la detecci�n de la tecla "Enter"
        respuestaInput.onSubmit.AddListener(delegate { ComprobarRespuesta(); });
    }

    void MostrarAcertijoRandom()
    {
        int indiceRandom = UnityEngine.Random.Range(0, acertijos.Count);
        acertijoText.text = acertijos[indiceRandom];
    }

    public void ComprobarRespuesta()
    {
        string respuestaUsuario = respuestaInput.text.ToLower(); // Convertir a min�sculas para comparaci�n sin distinci�n entre may�sculas y min�sculas

        if (respuestaUsuario == respuestas[0] && acertijoText.text== "Por un caminito, va caminando un bicho. El nombre del bicho ya te lo he dicho" ||
        respuestaUsuario == respuestas[1] && acertijoText.text == "Húmedo por dentro, con pelos por fuera. Comienza por la C. ¿De qué se trata?" ||
        respuestaUsuario == respuestas[2] && acertijoText.text == "Lo levanto cuando estoy contento, pero es más pequeño que el resto. ¿Qué es?" || 
        respuestaUsuario == respuestas[3] && acertijoText.text == "Tiene famosa memoria, gran tamaño y dura piel y la nariz más grandota, que en el mundo pueda haber" ||
        respuestaUsuario == respuestas[4] && acertijoText.text == "En rincones y entre ramas mis redes voy construyendo, para que moscas incautas, en ellas vayan cayendo" ||
        respuestaUsuario == respuestas[5] && acertijoText.text == "Orejas largas, rabo cortito, corro y salto muy ligerito" ||
        respuestaUsuario == respuestas[6] && acertijoText.text == "Me llegan las cartas y no sé leer y, aunque me las trago, no mancho el papel. ¿Qué es?" ||
        respuestaUsuario == respuestas[7] && acertijoText.text == "Es pequeña como una pera, pero alumbra la casa entera. ¿Qué es?" ||
        respuestaUsuario == respuestas[8] && acertijoText.text == "Tengo teclas, pero no puedo tocar música. Tengo letras, pero no puedo hablar. ¿Qué soy?" ||
        respuestaUsuario == respuestas[9] && acertijoText.text == "¿Quién allí en lo alto en las ramas mora y allí esconde, avara, todo lo que roba?")
        {
           RespuestaCorrecta();
            // Aqu� puedes realizar acciones adicionales si la respuesta es correcta
        }
        else
        {
            actualizarTexto();
            PlayerPrefs.SetInt("aciertos", 0);
            acertijoText.text = "�Incorrecto!, no has acertado el acertijo :(";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("No has acertado");
            // Aqu� puedes realizar acciones adicionales si la respuesta es incorrecta
        }

        // Limpiar el campo de entrada
        respuestaInput.text = "";

        // Mostrar un nuevo acertijo despu�s de cada respuesta
        //MostrarAcertijoRandom();
    }

    void RespuestaCorrecta()
    {
        aciertos++;
            actualizarTexto();
            PlayerPrefs.SetInt("aciertos", aciertos);
            acertijoText.text = "¡Correcto!, has acertado el acertijo";
            botonContinuar.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue así");
    }

    public void actualizarTexto()
    {
        textContador.text = "Aciertos: " + aciertos.ToString();
    }

    public void BotonReinicio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BotonContinuar()
    {
        SceneManager.LoadScene("Acertijos");
    }

    public void FinDelJuego()
    {
        PlayerPrefs.SetInt("aciertos", 0);
        PlayerPrefs.SetInt("Acertijos",2);
        fraseFinalDelJuego.gameObject.SetActive(true);
        acertijoText.gameObject.SetActive(false);
        respuestaInput.gameObject.SetActive(false);
        botonSalir.gameObject.SetActive(true);
        Debug.Log("Le has dado al botón salir nivel");
    }
    
    public void BotonSalir()
    {
        SceneManager.LoadScene("Nivel1");
    }
}

